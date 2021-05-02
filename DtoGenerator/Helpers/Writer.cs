using System.Collections.Generic;
using System.IO;
using DtoGenerator.Models;

namespace DtoGenerator.Helpers
{
    public static class Writer
    {
        public static void WriteAllDtos(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                Builder.BuildFullOutput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                Builder.BuildPartOutput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.ts"),
                Builder.BuildCreateInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                Builder.BuildUpdateInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                Builder.BuildGetInput(dtoName, propertyComponents));

            FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                Builder.BuildDeleteInput(dtoName, propertyComponents));
        }

        public static void WriteFullOutput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "FullOutput.ts"),
                Builder.BuildFullOutput(dtoName, propertyComponents));
        }

        public static void WritePartOutput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, dtoName + "PartOutput.ts"),
                Builder.BuildPartOutput(dtoName, propertyComponents));
        }

        public static void WriteCreateInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Create" + dtoName + "Input.ts"),
                Builder.BuildCreateInput(dtoName, propertyComponents));
        }

        public static void WriteUpdateInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Update" + dtoName + "Input.ts"),
                Builder.BuildUpdateInput(dtoName, propertyComponents));
        }

        public static void WriteGetInput(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Get" + dtoName + "Input.ts"),
                Builder.BuildGetInput(dtoName, propertyComponents));
        }

        public static void WriteDeleteInput(string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            FileHelpers.WriteDtoFile(Path.Combine(directory, "Delete" + dtoName + "Input.ts"),
                Builder.BuildDeleteInput(dtoName, propertyComponents));
        }
    }
}