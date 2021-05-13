using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environments.Enums;
using Environments.Models;

namespace Dto
{
    public static class CsDtoBuilder
    {
        public static string BuildDtoTemplate(string entityName, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var nameSpace = propertyComponents.FirstOrDefault(x => x.IsNamespace);
            if (nameSpace != null)
            {
                stringBuilder.AppendLine("namespace " + nameSpace.Name + ".Domain." + entityName + ".Dtos");
            }

            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine("    public class " + dtoName);
            stringBuilder.AppendLine("    {");
            foreach (PropertyComponent propertyComponent in propertyComponents.Where(x => !x.IsNamespace))
            {
                if (propertyComponent.PropertyType is PropertyType.FullOutput or PropertyType.PartOutput)
                {
                    if (propertyComponent.IsArray)
                    {
                        stringBuilder.AppendLine("        public List<" + propertyComponent.ArrayType + "Dto> " +
                                                 propertyComponent.Name + " { get; set; }  ");
                    }
                    else
                    {
                        stringBuilder.AppendLine("        public " + propertyComponent.PropertyTypeString + "Dto " +
                                                 propertyComponent.Name + " { get; set; }  ");
                    }
                }
                else
                {
                    stringBuilder.AppendLine("        public " + propertyComponent.PropertyTypeString + " " +
                                             propertyComponent.Name + " { get; set; }  ");
                }
            }

            stringBuilder.AppendLine("    }");
            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }

        public static void BuildAll(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            BuildCreateInput(dtoName, propertyComponents);
            BuildUpdateInput(dtoName, propertyComponents);
            BuildGetInput(dtoName, propertyComponents);
            BuildDeleteInput(dtoName, propertyComponents);
            BuildDto(dtoName, propertyComponents);
            // BuildPartOutput(dtoName, propertyComponents);
        }

        public static string BuildDto(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName, dtoName + "Dto", propertyComponents);
        }

        // public static string BuildPartOutput(string dtoName, List<PropertyComponent> propertyComponents)
        // {
        //     return BuildDtoTemplate(dtoName, dtoName + "PartOutput",
        //         propertyComponents.Where(x =>
        //             x.PropertyType != PropertyType.FullOutput &&
        //             x.PropertyType != PropertyType.PartOutput).ToList());
        // }

        public static string BuildCreateInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName, "Create" + dtoName + "Input",
                propertyComponents.Where(x =>
                    !x.Name.ToLower().Equals("id") &&
                    x.PropertyType != PropertyType.FullOutput &&
                    x.PropertyType != PropertyType.PartOutput).ToList());
        }

        public static string BuildUpdateInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName, "Update" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.PropertyType != PropertyType.FullOutput &&
                    x.PropertyType != PropertyType.PartOutput).ToList());
        }

        public static string BuildGetInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName, "Get" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.Name.ToLower().Equals("id") || x.IsNamespace).ToList());
        }

        public static string BuildDeleteInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName, "Delete" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.Name.ToLower().Equals("id") || x.IsNamespace).ToList());
        }
    }
}