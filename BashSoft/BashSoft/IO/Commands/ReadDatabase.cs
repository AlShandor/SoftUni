namespace BashSoft
{
    internal class ReadDatabase : Command
    {
        public ReadDatabase(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string fileName = Data[1];
            this.Repository.LoadData(fileName);
        }
    }
}