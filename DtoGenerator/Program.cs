using System;
using System.Collections.Generic;
using System.IO;
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
            
            if (filePath != null && !filePath.EndsWith(".cs"))
            {
                Console.WriteLine("Selected file is not an Entity");
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
            }

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
            
            
            Console.WriteLine("Enter endpoint:");
            string endPoint = Console.ReadLine();

            
            
        }
    }
}