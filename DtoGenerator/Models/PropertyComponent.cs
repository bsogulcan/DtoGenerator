#nullable enable
using DtoGenerator.Enums;

namespace DtoGenerator.Models
{
    public class PropertyComponent
    {
        public string Name { get; set; }
        public PropertyType PropertyType { get; set; }
        public bool IsArray { get; set; }
        public string? ArrayType { get; set; }
    }
}