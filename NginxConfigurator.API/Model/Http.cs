using System.Collections.Generic;

namespace NginxConfigurator.API.Model
{
    public class Http
    {
        public Http()
        {
            Upstreams = new List<Upstream>();
            ProxyHeaders = new Dictionary<string, string>();
        }
        
        public List<Upstream> Upstreams { get; set; }

        public Server Server { get; set; }
        
        public string LogFormat { get; set; }
        
        public Dictionary<string, string> ProxyHeaders { get; set; }
    }
}
