using Environments.Enums;

namespace Business.Helpers
{
    public static class PropertyHelpers
    {
        public static string FirstCharToLowerCase(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || char.IsLower(propertyName[0]))
                return propertyName;

            return char.ToLower(propertyName[0]) + propertyName.Substring(1);
        }

        public static string GetArrayTypeFromLine(string line)
        {
            int startIndex = line.IndexOf("<") + 1;
            int endIndex = line.IndexOf(">") - startIndex;
            var arrayType = line.Substring(startIndex, endIndex);
            return arrayType;
        }

        public static bool IsGetOrSet(string component)
        {
            return component.ToLower() == "{" ||
                   component.ToLower() == "get;" ||
                   component.ToLower() == "set;" ||
                   component.ToLower() == "}";
        }

        public static bool IsArray(string line)
        {
            return line.ToLower().Contains("icollection") || line.ToLower().Contains("list");
        }

        public static bool IsRowVersion(string line)
        {
            return line.ToLower().Contains("rowversion");
        }

        public static bool IsAccessModifiers(string component)
        {
            return component.ToLower() == "public" ||
                   component.ToLower() == "private" ||
                   component.ToLower() == "protected";
        }


        public static bool IsNameSpace(string component)
        {
            return component.ToLower().Contains("namespace");
        }


        public static bool IsVirtual(string component)
        {
            return component.ToLower().Contains("virtual");
        }

        public static bool IsPropertyType(string component)
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

        public static PropertyType GetPropertyTypeFromComponent(string component)
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