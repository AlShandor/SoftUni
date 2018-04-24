
namespace Database
{
    public class Startup
    {
        public static void Main()
        {
            int[] ints = {0, 1, 2, 3};
            var database = new Database(ints);
            database.Add(4);
        }
    }
}
