using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DtoGenerator.Enums;
using DtoGenerator.Models;

namespace DtoGenerator.Helpers
{
    public static class FileHelpers
    {
        public static IEnumerable<string> GetPropertyLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Where(a => (a.Contains("public")) &&
                            !a.Contains("_") &&
                            !a.Contains("class") &&
                            !a.Contains("()"));
        }

        public static void WriteDtoFile(string filePath,string outputString)
        {
            FileStream fileStream = File.Create(filePath);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(outputString);
            streamWriter.Close();
        }
    }
}