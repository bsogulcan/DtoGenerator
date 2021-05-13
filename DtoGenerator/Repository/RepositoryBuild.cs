using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business;
using Business.Helpers;
using Environments.Models;

namespace Generator.Repository
{
    public static class RepositoryBuilder
    {
        public static void Build(Setting setting)
        {
            FileAttributes fileAttributes = File.GetAttributes(setting.InputDirectory);

            if (fileAttributes.HasFlag(FileAttributes.Directory))
            {
                if (setting.FileName == string.Empty)
                {
                    string[] files = Directory.GetFiles(setting.InputDirectory);
                    foreach (string filePath in files.Where(x => x.Contains(".cs")).ToList())
                    {
                        setting.FileName = FileHelpers.GetFileName(filePath);

                        
                    }
                }
                else
                {
                    List<PropertyComponent> propertyComponent =
                        Property.CreatePropertyComponents(Path.Combine(setting.InputDirectory, setting.FileName));
                }
            }
            else
            {
                if (setting.FileName == string.Empty)
                    setting.FileName = FileHelpers.GetFileName(setting.InputDirectory);

                List<PropertyComponent> propertyComponent = Property.CreatePropertyComponents(setting.InputDirectory);
            }
        }
    }
}