using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Helpers
{
    public static class FileHelpers
    {
        public static IEnumerable<string> GetPropertyLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Where(a => (a.Contains("public")||a.Contains("namespace")) &&
                            !a.Contains("class") &&
                            !a.Contains("()"));
        }

        public static void WriteDtoFile(string filePath, string outputString)
        {
            FileStream fileStream = File.Create(filePath);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(outputString);
            streamWriter.Close();
        }

        public static string GetFileName(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(".", StringComparison.Ordinal));
        }
    }
}