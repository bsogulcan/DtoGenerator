using System;
using System.Linq;
using DtoGenerator;
using Environments.Enums;
using Environments.Models;
using Generator.Repository;

namespace Generator
{
    static class Program
    {
        private static readonly string _currentDirectory = Environment.CurrentDirectory;
        private static string _inputDirectory = _currentDirectory;
        private static string _outputDirectory = string.Empty;
        private static string _fileName = string.Empty;

        private static bool _buildAll = true;
        private static bool _buildFullOutput;
        private static bool _buildPartOutput;
        private static bool _buildCreateInput;
        private static bool _buildUpdateInput;
        private static bool _buildGetInput;
        private static bool _buildDeleteInput;

        private static ProcessType _processType;
        private static FrameworkType _frameworkType;


        static void Main(string[] args)
        {
            if (!ArgsChecker(args))
            {
                return;
            }

            if (_inputDirectory == string.Empty)
            {
                Console.WriteLine("Enter the file path:");
                _inputDirectory = Console.ReadLine();
            }

            if (_outputDirectory == string.Empty)
            {
                Console.WriteLine("Enter endpoint:");
                _outputDirectory = Console.ReadLine();
            }

            Setting setting = new Setting(_processType, _frameworkType, _inputDirectory, _outputDirectory,
                _fileName, _buildAll, _buildFullOutput, _buildPartOutput, _buildCreateInput, _buildUpdateInput,
                _buildGetInput, _buildDeleteInput);

            if (_processType == ProcessType.Dto)
            {
                DtoBuilder.DtoBuild(setting);
            }
            else if (_processType == ProcessType.Repository)
            {
                RepositoryBuilder.Build(setting);
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

                if (!args.Contains("dto") && !args.Contains("repository"))
                {
                    Console.WriteLine("You must select generation type. etc:dto,repository");
                    return false;
                }

                if (args.Contains("dto") && !(args.Contains("ts") || args.Contains("cs")))
                {
                    Console.WriteLine("You must select converting module. etc:ts,cs");
                    return false;
                }

                if (args.Contains("dto"))
                    _processType = ProcessType.Dto;

                if (args.Contains("ts"))
                    _frameworkType = FrameworkType.Ts;

                if (args.Contains("cs"))
                    _frameworkType = FrameworkType.Cs;

                if (args.Contains("repository"))
                {
                    _processType = ProcessType.Repository;
                }

                if (!args.Contains("-o") && !args.Contains("--outputPath"))
                {
                    Console.WriteLine("Output path is invalid! -h for helps.");
                    return false;
                }

                if (args[i].ToLower() == "-p" || args[i].ToLower() == "--path")
                {
                    if (args[i + 1] != null)
                    {
                        _inputDirectory = args[i + 1];
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
                        _outputDirectory = args[i + 1];
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
                        _fileName = args[i + 1];
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
                    _buildAll = false;
                }

                if (args[i].ToLower() == "fulloutput")
                {
                    _buildFullOutput = true;
                }

                if (args[i].ToLower() == "partoutput")
                {
                    _buildPartOutput = true;
                }

                if (args[i].ToLower() == "createinput")
                {
                    _buildCreateInput = true;
                }

                if (args[i].ToLower() == "deleteinput")
                {
                    _buildDeleteInput = true;
                }

                if (args[i].ToLower() == "getinput")
                {
                    _buildGetInput = true;
                }

                if (args[i].ToLower() == "updateinput")
                {
                    _buildUpdateInput = true;
                }
            }

            return true;
        }
    }
}