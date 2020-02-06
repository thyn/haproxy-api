using System;

namespace HAProxyApi.Client.Models
{
    [AttributeUsage( AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; }
		
        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}