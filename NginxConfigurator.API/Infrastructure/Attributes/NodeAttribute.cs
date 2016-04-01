using System;

namespace NginxConfigurator.API.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class NodeAttribute : Attribute
    {
        public string Name { get; private set; }
        public NodeAttribute(string name)
        {
            Name = name;
        }
    }
}
