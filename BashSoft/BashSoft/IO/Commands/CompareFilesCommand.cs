using System;

namespace BashSoft
{
    internal class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length == 3)
            {
                string firstPath = Data[1];
                string secondPath = Data[2];
                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new ArgumentException(this.Input);
            }
        }
    }
}