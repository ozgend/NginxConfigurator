using System.Collections.Generic;
using NginxConfigurator.API.Model;

namespace NginxConfigurator.API.Infrastructure
{
    public interface INginxConfiguration
    {
        int WorkerProcesses { get; set; }
        int WorkerConnections { get; set; }
        Server Server { get; set; }
        string LogFormat { get; set; }
        Dictionary<string, string> ProxyHeaders { get; set; }
    }
}