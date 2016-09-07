using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NginxConfigurator.API.Internal;
using NginxConfigurator.API.Model;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace NginxConfigurator.API.Infrastructure
{
    public class DefaultNginxConfigurator : INginxConfigurator
    {
        private string _templateContent;
        private INginxConfiguration _configuration;

        public DefaultNginxConfigurator()
        {
            Create();
        }

        public INginxConfiguration GetConfigurationInstance()
        {
            return _configuration;
        }

        public void Create(string templateContent = null)
        {
            _templateContent = templateContent ?? ResourceHelper.ReadEmbeddedResource("Template.nginx.conf.template", Assembly.GetExecutingAssembly());
            _configuration = new NginxConfiguration();
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

        public string MakeConfigurationFile(string outputPath = null)
        {
            // https://github.com/Antaris/RazorEngine/issues/244
            using (var service = IsolatedRazorEngineService.Create(AppdomainHelper.SandboxCreator))
            {
                var contents = service.RunCompile(_templateContent, "nginx.configuration", typeof(INginxConfiguration), _configuration);

                if (outputPath != null)
                {
                    File.WriteAllText(outputPath, contents);
                    Console.WriteLine("configuration file created - {0}", outputPath);
                }

                return contents;
            }
        }

    }
}
