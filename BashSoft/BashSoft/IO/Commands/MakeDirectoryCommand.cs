using System;
using BashSoft;

public class MakeDirectoryCommand : Command
{
    public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (Data.Length == 2)
        {
            string folderName = Data[1];
            this.InputOutputMenager.CreateDirectoryInCurrentFolder(folderName);
        }
        else
        {
            throw new InvalidCommandException(this.Input);
        }
    }
}

