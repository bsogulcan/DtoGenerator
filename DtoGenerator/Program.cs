using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Environments.Enums;
using Environments.Models;

namespace DtoGenerator
{
    class Program
    {
        private static string CurrentDirectory = Environment.CurrentDirectory;
        private static string InputDirectory = CurrentDirectory;
        private static string OutputDirectory = string.Empty;
        private static string FileName = string.Empty;

        private static bool BuildAll = true;
        private static bool BuildFullOutput = false;
        private static bool BuildPartOutput = false;
        private static bool BuildCreateInput = false;
        private static bool BuildUpdateInput = false;
        private static bool BuildGetInput = false;
        private static bool BuildDeleteInput = false;

        private static ProcessType ProcessType;
        private static FrameworkType FrameworkType;


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
        }


        static bool ArgsChecker(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-h")
                {
                    Console.WriteLine("--Help Page--" +
                                      "" + Environment.NewLine +
                                      "-o || --outputPath : The directory to save the dto files. " +
                                      "" + Environment.NewLine +
                                      "-p || --path <Optional> : It will create all Entities Dtos from current folder." +
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
                    return false;
                }

                if (!args.Contains("dto"))
                {
                    Console.WriteLine("You must select generation type. etc:dto,appservices");
                    return false;
                }

                if (args.Contains("dto") && !(args.Contains("ts") || args.Contains("cs")))
                {
                    Console.WriteLine("You must select converting module. etc:ts,cs");
                    return false;
                }

                if (args.Contains("dto"))
                    ProcessType = ProcessType.Dto;

                if (args.Contains("ts"))
                    FrameworkType = FrameworkType.Ts;

                if (args.Contains("cs"))
                    FrameworkType = FrameworkType.Cs;

                if (!args.Contains("-o") && !args.Contains("--outputPath"))
                {
                    Console.WriteLine("Output path is invalid! -h for helps.");
                    return false;
                }

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


        static void WriteDtoFiles(string directory, string dtoName, List<PropertyComponent> propertyComponents)
        {
            string combinedDirectoryPath = Path.Combine(directory, dtoName);
            if (!Directory.Exists(combinedDirectoryPath))
            {
                Directory.CreateDirectory(combinedDirectoryPath);
            }

            if (BuildAll)
            {
                Writer.WriteAllDtos(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated " + dtoName + " Dtos.");
                return;
            }

            if (BuildFullOutput)
            {
                Writer.WriteFullOutput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated '" + dtoName + "FullOutPut.'");
            }


            if (BuildPartOutput)
            {
                Writer.WritePartOutput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated '" + dtoName + "PartOutPut.'");
            }

            if (BuildCreateInput)
            {
                Writer.WriteCreateInput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Create" + dtoName + "Input.'");
            }

            if (BuildUpdateInput)
            {
                Writer.WriteUpdateInput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Update" + dtoName + "Input.'");
            }

            if (BuildGetInput)
            {
                Writer.WriteGetInput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Get" + dtoName + "Input.'");
            }

            if (BuildDeleteInput)
            {
                Writer.WriteDeleteInput(combinedDirectoryPath, dtoName, propertyComponents);
                Console.WriteLine("Generated 'Delete" + dtoName + "Input.'");
            }
        }
    }
}