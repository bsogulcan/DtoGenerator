﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DtoGenerator.Enums;
using DtoGenerator.Helpers;
using DtoGenerator.Models;

namespace DtoGenerator
{
    class Program
    {
        private static string CurrentDirectory = Environment.CurrentDirectory;
        private static string InputDirectory = string.Empty;
        private static string OutputDirectory = string.Empty;
        private static string FileName = string.Empty;

        private static bool BuildAll = true;
        private static bool BuildFullOutput = false;
        private static bool BuildPartOutput = false;
        private static bool BuildCreateInput = false;
        private static bool BuildUpdateInput = false;
        private static bool BuildGetInput = false;
        private static bool BuildDeleteInput = false;

        static void Main(string[] args)
        {
            if (!ArgsChecker(args))
            {
                return;
            }

            if (InputDirectory == string.Empty)
            {
                Console.WriteLine("Enter the file path:");
                InputDirectory = Console.ReadLine();
            }

            if (OutputDirectory == string.Empty)
            {
                Console.WriteLine("Enter endpoint:");
                OutputDirectory = Console.ReadLine();
            }

            FileAttributes fileAttributes = File.GetAttributes(InputDirectory);

            if (fileAttributes.HasFlag(FileAttributes.Directory))
            {
                if (FileName == string.Empty)
                {
                    string[] files = Directory.GetFiles(InputDirectory);
                    foreach (string filePath in files.Where(x => x.Contains(".cs")).ToList())
                    {
                        FileName = FileHelpers.GetFileName(filePath);

                        List<PropertyComponent> propertyComponent = CreatePropertyComponents(filePath);
                        WriteDtoFiles(OutputDirectory, FileName, propertyComponent);
                    }
                }
            }
            else
            {
                if (FileName == string.Empty)
                    FileName = FileHelpers.GetFileName(InputDirectory);

                List<PropertyComponent> propertyComponent = CreatePropertyComponents(InputDirectory);
            }
        }


        static bool ArgsChecker(string[] args)
        {
            if (!args.Contains("-o") && !args.Contains("--outputPath"))
            {
                Console.WriteLine("Output path is invalid! -h for helps.");
                return false;
            }


            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-h")
                    Console.WriteLine("--Help Page--" +
                                      "" + Environment.NewLine +
                                      "-o || --outputPath : The directory to save the dto files. " +
                                      "" + Environment.NewLine +
                                      "-p || --path <Optional> : It will create all Entities Dto from current folder." +
                                      "" + Environment.NewLine + "-f || --file <Optional> : Specific file name." +
                                      "" + Environment.NewLine + "fulloutput <Optional> : It will create FullOutPut." +
                                      "" + Environment.NewLine + "partoutput <Optional> : It will create PartOutPut." +
                                      "" + Environment.NewLine +
                                      "createinput <Optional> : It will create CreateInput." +
                                      "" + Environment.NewLine +
                                      "updateinput <Optional> : It will create UpdateInput." +
                                      "" + Environment.NewLine + "getinput <Optional> : It will create GetInput." +
                                      "" + Environment.NewLine + "deleteinput <Optional> : It will create DeleteInput."
                    );

                if (args[i].ToLower() == "-p" || args[i].ToLower() == "--path")
                {
                    if (args[i + 1] != null)
                    {
                        InputDirectory = args[i + 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid path!");
                        return false;
                    }
                }

                if (args[i].ToLower() == "-o" || args[i].ToLower() == "--outputPath")
                {
                    if (args[i + 1] != null)
                    {
                        OutputDirectory = args[i + 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid path!");
                        return false;
                    }
                }

                if (args[i].ToLower() == "-f" || args[i].ToLower() == "--file")
                {
                    if (args[i + 1] != null)
                    {
                        FileName = args[i + 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid path!");
                        return false;
                    }
                }


                if (args.Contains("fulloutput") || args.Contains("partoutput") || args.Contains("createinput") ||
                    args.Contains("deleteinput") || args.Contains("getinput") || args.Contains("updateinput"))
                {
                    BuildAll = false;
                }

                if (args[i].ToLower() == "fulloutput")
                {
                    BuildFullOutput = true;
                }

                if (args[i].ToLower() == "partoutput")
                {
                    BuildPartOutput = true;
                }

                if (args[i].ToLower() == "createinput")
                {
                    BuildCreateInput = true;
                }

                if (args[i].ToLower() == "deleteinput")
                {
                    BuildDeleteInput = true;
                }

                if (args[i].ToLower() == "getinput")
                {
                    BuildGetInput = true;
                }

                if (args[i].ToLower() == "updateinput")
                {
                    BuildUpdateInput = true;
                }
            }

            return true;
        }

        static List<PropertyComponent> CreatePropertyComponents(string filePath)
        {
            List<PropertyComponent> propertyComponents = new List<PropertyComponent>();
            var propertyLines = FileHelpers.GetPropertyLinesFromFile(filePath);

            if (File.ReadAllText(filePath).Contains("AuditedEntity"))
                propertyComponents.Add(new PropertyComponent
                {
                    Name = "Id",
                    PropertyType = PropertyType.Number
                });

            foreach (var propertyLine in propertyLines)
            {
                PropertyComponent propertyComponent = PropertyHelpers.GetComponentsFromLine(propertyLine);
                if (propertyComponent != null)
                    propertyComponents.Add(propertyComponent);
            }

            // Writer.WriteAllDtos(OutputDirectory, FileName, propertyComponents);
            return propertyComponents;
        }

        static void WriteDtoFiles(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            if (BuildAll)
            {
                Writer.WriteAllDtos(directory, dtoName, propertyComponents);
                return;
            }
            
            
        }
    }
}