using System.Collections.Generic;
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
                stringBuilder.Append("    " + propertyComponent.Name + ": ");

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
    }
}