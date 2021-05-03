# DtoGenerator
DtoGenerator converting  entities to TypeScript classes and create **FullOutput**, **PartOutput**, **CreateInput**, **UpdateInput**, **GetInput**, **DeleteInput** files.

# Installing
npm i -g entitytotsgenerator

# Usage
cmd => GenerateDto -p "../Core/Entities/" -o "Desktop/GeneratedDtos"

# Commands
1. -o || --outputPath : The directory to save the dto files.
1. -p || --path <Optional> : It will create all Entities Dto from current folder.
1. -f || --file <Optional> : Specific file name.
1. fulloutput <Optional> : It will create FullOutPut.
1. partoutput <Optional> : It will create PartOutPut.
1. createinput <Optional> : It will create CreateInput.
1. updateinput <Optional> : It will create UpdateInput.
1. getinput <Optional> : It will create GetInput.
1. deleteinput <Optional> : It will create DeleteInput.
