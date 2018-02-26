using System;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder();
            int numOfCommands = int.Parse(Console.ReadLine());
            Stack<string> commandHistory = new Stack<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(' ');
                string command = tokens[0];

                switch (command)
                {
                    case "1":
                        text.Append(tokens[1]);
                        commandHistory.Push(input);
                        break;
                    case "2":
                        int countElementsToRemove = int.Parse(tokens[1]);
                        string removedText = text.ToString().Substring(text.Length - countElementsToRemove, countElementsToRemove);
                        text.Remove(text.Length - countElementsToRemove, countElementsToRemove);
                        commandHistory.Push("2 " + removedText);
                        break;
                    case "3":
                        int indexOfLetterToReturn = int.Parse(tokens[1]) - 1;
                        Console.WriteLine(text[indexOfLetterToReturn]);
                        break;
                    case "4":
                        UndoLastCommand(text, commandHistory);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void UndoLastCommand(StringBuilder text, Stack<string> commandHistory)
        {
            string[] tokens = commandHistory.Pop().Split(' ');
            int command = int.Parse(tokens[0]);
            if (command == 1)
            {
                int lengthOfAppendedText = tokens[1].Length;
                text.Remove(text.Length - lengthOfAppendedText, lengthOfAppendedText);
            }
            else
            {
                text.Append(tokens[1]);
            }
        }
    }
}
