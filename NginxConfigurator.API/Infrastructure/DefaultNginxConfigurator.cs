using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using NginxConfigurator.API.Internal;
using NginxConfigurator.API.Model;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace NginxConfigurator.API.Infrastructure
{
    public class DefaultNginxConfigurator : IConfigurator
    {
        const string DefaultTemplateName = "nginx.conf.template";
        private string _templateContent;
        private readonly Configuration _configuration;

        public DefaultNginxConfigurator(string templateContent = null)
        {
            _templateContent = templateContent ??
                              ResourceHelper.ReadEmbeddedResource("Template.nginx.conf.template", Assembly.GetExecutingAssembly());
            _configuration = new Configuration();
        }

        public void SetListeningServer(string name, int port)
        {
            _configuration.Server.Name = name;
            _configuration.Server.Port = port;
        }

        public void AddLocation(string upstreamName, string path, bool secure, List<Upstream> upstreams)
        {
            _configuration.Server.Locations.Add(new Location { UpstreamName = upstreamName, IsSecure = secure, Path = path, Upstreams = upstreams });
        }

        public void AddProxyHeader(string key, string value)
        {
            _configuration.ProxyHeaders[key] = value;
        }
        public void SetLogFormat(string format)
        {
            _configuration.LogFormat = format;
        }

        public void MakeConfigurationFile(string outputPath)
        {
            var config = new TemplateServiceConfiguration();
            config.EncodedStringFactory = new RawStringFactory(); // Raw string encoding.
            config.Debug = true;

            var service = RazorEngineService.Create(config);

            var contents = service.RunCompile(_templateContent, "nginx.configuration", typeof(Configuration), _configuration);
            File.WriteAllText(outputPath, contents);
            Console.WriteLine("configuration file created - {0}", outputPath);
        }

    }
}
