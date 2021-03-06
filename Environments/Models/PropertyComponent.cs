#nullable enable
using Environments.Enums;

namespace Environments.Models
{
    public class PropertyComponent
    {
        public string Name { get; set; }
        public string PropertyTypeString { get; set; }
        public PropertyType PropertyType { get; set; }
        public bool IsArray { get; set; }
        public string? ArrayType { get; set; }
        public bool IsNamespace { get; set; }
    }
}