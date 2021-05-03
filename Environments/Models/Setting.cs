using Environments.Enums;

namespace Environments.Models
{
    public class Setting
    {
        public Setting(ProcessType processType, FrameworkType frameworkType, string inputDirectory,
            string outputDirectory, string fileName, bool buildAll, bool buildFullOutput, bool buildPartOutput,
            bool buildCreateInput, bool buildUpdateInput, bool buildGetInput, bool buildDeleteInput)
        {
            ProcessType = processType;
            FrameworkType = frameworkType;
            InputDirectory = inputDirectory;
            OutputDirectory = outputDirectory;
            FileName = fileName;
            BuildAll = buildAll;
            BuildFullOutput = buildFullOutput;
            BuildPartOutput = buildPartOutput;
            BuildCreateInput = buildCreateInput;
            BuildUpdateInput = buildUpdateInput;
            BuildGetInput = buildGetInput;
            BuildDeleteInput = buildDeleteInput;
        }

        public string InputDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string FileName { get; set; }
        public bool BuildAll { get; set; }
        public bool BuildFullOutput { get; set; }
        public bool BuildPartOutput { get; set; }
        public bool BuildCreateInput { get; set; }
        public bool BuildUpdateInput { get; set; }
        public bool BuildGetInput { get; set; }
        public bool BuildDeleteInput { get; set; }
        public ProcessType ProcessType;
        public FrameworkType FrameworkType;
    }
}