using System;

namespace NginxConfigurator.API.Model
{
    [Serializable]
    public class Upstream
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
