namespace BashSoft
{
    internal class PrintOrderedStudentsCommand : Command
    {
        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
                if (Data.Length == 5)
                {
                    string courseName = Data[1];
                    string comparison = Data[2].ToLower();
                    string takeCommand = Data[3].ToLower();
                    string takeQuantity = Data[4].ToLower();

                   this.ParseParameters(takeCommand, takeQuantity, courseName, comparison);
                }
                else
                {
                    throw new InvalidCommandException(this.Input);
                }
            
        }

        private void ParseParameters(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, comparison, studentsToTake);
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