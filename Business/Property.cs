using Environments.Models;
using Environments.Enums;
using Business.Helpers;

namespace Business
{
    public class Property
    {
        public static PropertyComponent? GetComponentsFromLine(string line)
        {
            if (PropertyHelpers.IsRowVersion(line))
                return null;

            PropertyComponent propertyComponent = new PropertyComponent {IsArray = PropertyHelpers.IsArray(line)};

            string[] components = line.Trim().Split(" ");
            foreach (string component in components)
            {
                if (PropertyHelpers.IsAccessModifiers(component) || PropertyHelpers.IsGetOrSet(component))
                    continue;

                if (PropertyHelpers.IsPropertyType(component))
                {
                    propertyComponent.PropertyType = PropertyHelpers.GetPropertyTypeFromComponent(component);
                }
                else if (PropertyHelpers.IsVirtual(component))
                {
                    propertyComponent.PropertyType = PropertyType.PartOutput;
                }
                else
                {
                    if (PropertyHelpers.IsArray(component))
                    {
                        propertyComponent.ArrayType = PropertyHelpers.GetArrayTypeFromLine(component);
                    }

                    propertyComponent.Name = component;
                }
            }

            return propertyComponent;
        }

    }
}