namespace BashSoft
{
    internal class ChangeRelativePathCommand : Command
    {
        public ChangeRelativePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string relPath = Data[1];
            this.InputOutputMenager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}