using System;
using System.Collections.Generic;

namespace NginxConfigurator.API.Model
{
    [Serializable]
    public class Server
    {
        public Server()
        {
            Locations = new List<Location>();
        }

        public int Port { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }

    }
}
