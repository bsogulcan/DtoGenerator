using System.Collections.Generic;
using System.IO;
using Business.Helpers;
using Environments.Models;

namespace DtoGenerator.Helpers
{
    public static class Writer
    {
        public static void WriteAllDtos(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                Dto.TypeScriptDtoBuilder.BuildFullOutput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                Dto.TypeScriptDtoBuilder.BuildPartOutput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildCreateInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildGetInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
        }

        public static void WriteFullOutput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                Dto.TypeScriptDtoBuilder.BuildFullOutput(dtoName, propertyComponents));
        }

        public static void WritePartOutput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                Dto.TypeScriptDtoBuilder.BuildPartOutput(dtoName, propertyComponents));
        }

        public static void WriteCreateInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildCreateInput(dtoName, propertyComponents));
        }

        public static void WriteUpdateInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildUpdateInput(dtoName, propertyComponents));
        }

        public static void WriteGetInput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildGetInput(dtoName, propertyComponents));
        }

        public static void WriteDeleteInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                Dto.TypeScriptDtoBuilder.BuildDeleteInput(dtoName, propertyComponents));
        }
    }
}