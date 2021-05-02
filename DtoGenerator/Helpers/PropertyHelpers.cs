#nullable enable
using DtoGenerator.Enums;
using DtoGenerator.Models;

namespace DtoGenerator.Helpers
{
    public static class PropertyHelpers
    {
        public static PropertyComponent? GetComponentsFromLine(string line)
        {
            if (IsRowVersion(line))
                return null;

            PropertyComponent propertyComponent = new PropertyComponent {IsArray = IsArray(line)};

            string[] components = line.Trim().Split(" ");
            foreach (string component in components)
            {
                if (IsAccessModifiers(component) || IsGetOrSet(component))
                    continue;

                if (IsPropertyType(component))
                {
                    propertyComponent.PropertyType = GetPropertyTypeFromComponent(component);
                }
                else if (IsVirtual(component))
                {
                    propertyComponent.PropertyType = PropertyType.PartOutput;
                }
                else
                {
                    if (IsArray(component))
                    {
                        propertyComponent.ArrayType = GetArrayTypeFromLine(component);
                    }

                    propertyComponent.Name = component;
                }
            }

            return propertyComponent;
        }


        private static string GetArrayTypeFromLine(string line)
        {
            int startIndex = line.IndexOf("<") + 1;
            int endIndex = line.IndexOf(">") - startIndex;
            var arrayType = line.Substring(startIndex, endIndex);
            return arrayType;
        }

        private static bool IsGetOrSet(string component)
        {
            return component.ToLower() == "{" ||
                   component.ToLower() == "get;" ||
                   component.ToLower() == "set;" ||
                   component.ToLower() == "}";
        }

        private static bool IsArray(string line)
        {
            return line.ToLower().Contains("icollection") || line.ToLower().Contains("list");
        }

        private static bool IsRowVersion(string line)
        {
            return line.ToLower().Contains("rowversion");
        }

        private static bool IsAccessModifiers(string component)
        {
            return component.ToLower() == "public" ||
                   component.ToLower() == "private" ||
                   component.ToLower() == "protected";
        }

        private static bool IsVirtual(string component)
        {
            return component.ToLower().Contains("virtual");
        }

        private static bool IsPropertyType(string component)
        {
            if (component.ToLower() == "string" ||
                component.ToLower() == "int" ||
                component.ToLower() == "int?" ||
                component.ToLower() == "long" ||
                component.ToLower() == "long?" ||
                component.ToLower() == "float" ||
                component.ToLower() == "decimal" ||
                component.ToLower() == "double" ||
                component.ToLower() == "datetime")
                return true;

            return false;
        }

        private static PropertyType GetPropertyTypeFromComponent(string component)
        {
            switch (component.ToLower())
            {
                case "string":
                    return PropertyType.String;
                case "datetime":
                    return PropertyType.Date;
                case "int":
                    return PropertyType.Number;
                case "int?":
                    return PropertyType.Number;
                case "long":
                    return PropertyType.Number;
                case "long?":
                    return PropertyType.Number;
                case "float":
                    return PropertyType.Number;
                case "decimal":
                    return PropertyType.Number;
                case "double":
                    return PropertyType.Number;
                default:
                    return PropertyType.Any;
            }
        }
    }
}