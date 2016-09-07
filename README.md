# NginxConfigurator
very simple nginx configuration file builder via template



    var configurator = new DefaultNginxConfigurator();
    configurator.SetListeningServer("127.0.0.1", 1980);
    configurator.AddLocation("service-a", "/a", false, new List<Upstream> { new Upstream { Host = "127.0.0.1", Port = 901 }, new Upstream { Host = "127.0.0.1", Port = 902 } });
    configurator.AddLocation("service-b", "/b", false, new List<Upstream> { new Upstream { Host = "127.0.0.1", Port = 911 }, new Upstream { Host = "127.0.0.1", Port = 912 } });
    configurator.AddLocation("service-c", "/c", false, new List<Upstream> { new Upstream { Host = "127.0.0.1", Port = 921 }, new Upstream { Host = "127.0.0.1", Port = 922 } });
    configurator.MakeConfigurationFile(@"./nginx.sampleconfig");
