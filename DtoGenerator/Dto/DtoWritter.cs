using System;
using System.Collections.Generic;
using System.IO;
using Environments.Models;

namespace DtoGenerator.Writter
{
    public static class DtoWritter
    {
        public static void WriteDtoFiles(Setting setting, string directory, string dtoName,
            List<PropertyComponent> propertyComponents)
        {
            string combinedDirectoryPath = Path.Combine(directory, dtoName);
            if (!Directory.Exists(combinedDirectoryPath))
            {
                Directory.CreateDirectory(combinedDirectoryPath);
            }

            if (setting.BuildAll)
            {
                Writer.WriteAllDtos(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated " + dtoName + " Dtos.");
                return;
            }

            if (setting.BuildFullOutput)
            {
                Writer.WriteDto(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated '" + dtoName + "FullOutPut.'");
            }
            
            // if (setting.BuildPartOutput)
            // {
            //     Writer.WritePartOutput(setting,combinedDirectoryPath, dtoName, propertyComponents);
            //     Console.WriteLine("Generated '" + dtoName + "PartOutPut.'");
            // }

            if (setting.BuildCreateInput)
            {
                Writer.WriteCreateInput(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Create" + dtoName + "Input.'");
            }

            if (setting.BuildUpdateInput)
            {
                Writer.WriteUpdateInput(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Update" + dtoName + "Input.'");
            }

            if (setting.BuildGetInput)
            {
                Writer.WriteGetInput(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Get" + dtoName + "Input.'");
            }

            if (setting.BuildDeleteInput)
            {
                Writer.WriteDeleteInput(setting,combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Delete" + dtoName + "Input.'");
            }
        }
    }
}