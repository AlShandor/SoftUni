using System;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main()
        {
            var stringCollection = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printStrings = PrintCollectionOfString;
            printStrings(stringCollection);
        }

        public static void PrintCollectionOfString(string[] stringCollection)
        {
            foreach (var word in stringCollection)
            {
                Console.WriteLine(word);
            }
        }
    }
}
