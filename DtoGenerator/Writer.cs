using System.Collections.Generic;
using System.IO;
using Business.Helpers;
using Environments.Enums;
using Environments.Models;

namespace DtoGenerator
{
    public static class Writer
    {
        public static void WriteAllDtos(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                    Dto.TypeScriptDtoBuilder.BuildFullOutput(dtoName, propertyComponents)
                );

                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                    Dto.TypeScriptDtoBuilder.BuildFullOutput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildCreateInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildGetInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
            }
            else
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "Dto.cs"),
                    Dto.CsDtoBuilder.BuildFullOutput(dtoName, propertyComponents)
                );

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.cs"),
                    Dto.CsDtoBuilder.BuildCreateInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.cs"),
                    Dto.CsDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.cs"),
                    Dto.CsDtoBuilder.BuildGetInput(dtoName, propertyComponents));

                FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.cs"),
                    Dto.CsDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
            }
        }

        public static void WriteFullOutput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                    Dto.TypeScriptDtoBuilder.BuildFullOutput(dtoName, propertyComponents));
            else
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                    Dto.CsDtoBuilder.BuildFullOutput(dtoName, propertyComponents));
        }

        public static void WritePartOutput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                    Dto.TypeScriptDtoBuilder.BuildPartOutput(dtoName, propertyComponents));
            else
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                    Dto.CsDtoBuilder.BuildPartOutput(dtoName, propertyComponents));
        }

        public static void WriteCreateInput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                    Dto.TypeScriptDtoBuilder.BuildCreateInput(dtoName, propertyComponents));
            else
                FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                    Dto.CsDtoBuilder.BuildCreateInput(dtoName, propertyComponents));
        }

        public static void WriteUpdateInput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));
            }
            else
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                    Dto.CsDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));
            }
        }

        public static void WriteGetInput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildGetInput(dtoName, propertyComponents));
            }
            else
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                    Dto.CsDtoBuilder.BuildGetInput(dtoName, propertyComponents));
            }
        }

        public static void WriteDeleteInput(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            if (setting.FrameworkType == FrameworkType.Ts)
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                    Dto.TypeScriptDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
            }
            else
            {
                FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                    Dto.CsDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
            }
        }
    }
}