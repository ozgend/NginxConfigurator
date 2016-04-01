using System;

namespace NginxConfigurator.API.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class TemplateAttribute : Attribute
    {
        public string Value { get; private set; }
        public TemplateAttribute(string value)
        {
            Value = value;
        }
    }
}
