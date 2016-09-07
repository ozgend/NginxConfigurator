using System.Collections.Generic;
using NginxConfigurator.API.Model;

namespace NginxConfigurator.API.Infrastructure
{
    public interface INginxConfigurator
    {
        INginxConfiguration GetConfigurationInstance();
        void Create(string templateContent = null);
        void SetListeningServer(string name, int port);
        void AddLocation(string upstreamName, string path, bool secure, List<Upstream> upstreams);
        void AddProxyHeader(string key, string value);
        void SetLogFormat(string format);
        string MakeConfigurationFile(string outputPath = null);
    }
}
