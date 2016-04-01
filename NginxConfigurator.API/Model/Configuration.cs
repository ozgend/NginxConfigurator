using System.Collections.Generic;

namespace NginxConfigurator.API.Model
{
    public class Configuration
    {
        public Configuration()
        {
            ProxyHeaders = new Dictionary<string, string>();
            Server = new Server();
            WorkerProcesses = 1;
            WorkerConnections = 1024;
            LogFormat = @"'[$time_local] $remote_addr - $remote_user - $server_name  to: $upstream_addr: $request upstream_response_time $upstream_response_time msec $msec request_time $request_time';";
        }

        public int WorkerProcesses { get; set; }
        public int WorkerConnections { get; set; }

        public Server Server { get; set; }

        public string LogFormat { get; set; }

        public Dictionary<string, string> ProxyHeaders { get; set; }
    }
}
