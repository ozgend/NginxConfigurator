using System;

namespace NginxConfigurator.API.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class KeyAttribute : Attribute
    {
        public string Name { get; private set; }
        public KeyAttribute(string name)
        {
            Name = name;
        }
    }
}
