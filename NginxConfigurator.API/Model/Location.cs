using System;
using System.Collections.Generic;

namespace NginxConfigurator.API.Model
{
    [Serializable]
    public class Location
    {
        public Location()
        {
            Upstreams = new List<Upstream>();
        }
        public string Path { get; set; }
        public string UpstreamName { get; set; }
        public List<Upstream> Upstreams { get; set; }
        public bool IsSecure { get; set; }
    }
}