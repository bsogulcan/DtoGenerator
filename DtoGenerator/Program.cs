using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using DtoGenerator.Enums;
using DtoGenerator.Helpers;
using DtoGenerator.Models;

namespace DtoGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path:");
            var filePath = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(filePath);


            if (fileInfo.Extension != ".cs")
            {
                Console.WriteLine("Selected file is not an Entity");
                return;
            }

            if (!fileInfo.Exists)
            {
                Console.WriteLine("File not found");
                return;
            }

            Console.WriteLine("Enter endpoint:");
            string endPoint = Console.ReadLine();

            DirectoryInfo directoryInfo = new DirectoryInfo(endPoint);
            if (!directoryInfo.Exists)
            {
                Console.WriteLine("Selected file is not an Entity");
                return;
            }

            string fileName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".", StringComparison.Ordinal));


            List<PropertyComponent> propertyComponents = new List<PropertyComponent>();

            var propertyLines = FileHelpers.GetPropertyLinesFromFile(filePath);

            if (File.ReadAllText(filePath).Contains("AuditedEntity"))
            {
                propertyComponents.Add(new PropertyComponent
                {
                    Name = "Id",
                    PropertyType = PropertyType.Number
                });
            }

            foreach (var propertyLine in propertyLines)
            {
                PropertyComponent propertyComponent = PropertyHelpers.GetComponentsFromLine(propertyLine);
                if (propertyComponent != null)
                {
                    Console.WriteLine(propertyComponent.Name + " - " +
                                      propertyComponent.PropertyType + " - " +
                                      propertyComponent.IsArray + " - " +
                                      propertyComponent.ArrayType + " - ");
                    propertyComponents.Add(propertyComponent);
                }
            }
            
            string outPutString = Builder.BuildDtoTemplate(fileName, propertyComponents);
            FileHelpers.WriteDtoFile(Path.Combine(endPoint, fileName + ".ts"), outPutString);
        }
    }
}