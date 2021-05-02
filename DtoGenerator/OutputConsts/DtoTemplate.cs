namespace DtoGenerator.OutputConsts
{
    public static class DtoTemplate
    {
        public static string dtoTemplateString { get; set; } = @"
            export class %DtoName% {
                name: string;
                departmant: DepartmantPartOutput;
            }";
    }
}