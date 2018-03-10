using System;

namespace BashSoft
{
    internal class PrintFilteredStudentsCommand : Command
    {
        public PrintFilteredStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length == 5)
            {
                string courseName = Data[1];
                string filter = Data[2].ToLower();
                string takeCommand = Data[3].ToLower();
                string takeQuantity = Data[4].ToLower();

                this.ParseParameters(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                throw new ArgumentException(this.Input);
            }
        }

        private void ParseParameters(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantity);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }
    }
}