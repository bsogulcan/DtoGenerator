﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using DtoGenerator.Enums;
using DtoGenerator.Models;

namespace DtoGenerator.Helpers
{
    public static class Builder
    {
        public static string BuildDtoTemplate(string dtoName, List<PropertyComponent> propertyComponents)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("export class " + dtoName + " {");
            foreach (PropertyComponent propertyComponent in propertyComponents)
            {
                stringBuilder.Append("    " + PropertyHelpers.FirstCharToLowerCase(propertyComponent.Name) + ": ");

                if (propertyComponent.IsArray)
                {
                    string outputType = propertyComponent.PropertyType == PropertyType.FullOutput
                        ? "FullOutput"
                        : "PartOutput";

                    stringBuilder.AppendLine("Array<" + propertyComponent.ArrayType + outputType + ">;");
                }
                else
                {
                    switch (propertyComponent.PropertyType)
                    {
                        case PropertyType.String:
                            stringBuilder.AppendLine("string;");
                            break;
                        case PropertyType.Number:
                            stringBuilder.AppendLine("number;");
                            break;
                        case PropertyType.Date:
                            stringBuilder.AppendLine("Date;");
                            break;
                        case PropertyType.FullOutput:
                            stringBuilder.AppendLine(propertyComponent.Name + "FullOutput;");
                            break;
                        case PropertyType.PartOutput:
                            stringBuilder.AppendLine(propertyComponent.Name + "PartOutput;");
                            break;
                        case PropertyType.Any:
                            stringBuilder.AppendLine("any;");
                            break;
                    }
                }
            }

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static void BuildAll(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            BuildCreateInput(dtoName, propertyComponents);
            BuildUpdateInput(dtoName, propertyComponents);
            BuildGetInput(dtoName, propertyComponents);
            BuildDeleteInput(dtoName, propertyComponents);
            BuildFullOutput(dtoName, propertyComponents);
            BuildPartOutput(dtoName, propertyComponents);
        }

        public static string BuildFullOutput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName + "FullOutput", propertyComponents);
        }

        public static string BuildPartOutput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate(dtoName + "PartOutput",
                propertyComponents.Where(x =>
                    x.PropertyType != PropertyType.FullOutput &&
                    x.PropertyType != PropertyType.PartOutput).ToList());
        }

        public static string BuildCreateInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate("Create" + dtoName + "Input",
                propertyComponents.Where(x =>
                    !x.Name.ToLower().Equals("id") &&
                    x.PropertyType != PropertyType.FullOutput &&
                    x.PropertyType != PropertyType.PartOutput).ToList());
        }

        public static string BuildUpdateInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate("Update" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.PropertyType != PropertyType.FullOutput &&
                    x.PropertyType != PropertyType.PartOutput).ToList());
        }

        public static string BuildGetInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate("Get" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.Name.ToLower().Equals("id")).ToList());
        }

        public static string BuildDeleteInput(string dtoName, List<PropertyComponent> propertyComponents)
        {
            return BuildDtoTemplate("Delete" + dtoName + "Input",
                propertyComponents.Where(x =>
                    x.Name.ToLower().Equals("id")).ToList());
        }
    }
}