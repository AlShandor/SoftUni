using System;
using System.Linq;

namespace _02.Ladybugs
{
    class Program
    {
        static void Main()
        {
            int arrLength = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] bugsOnField = new int[arrLength];
            PutBugsOnField(bugsOnField, ladybugIndexes);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                MoveLadyBug(bugsOnField, input);
            }
            Console.WriteLine(string.Join(" ", bugsOnField));
        }

        private static void MoveLadyBug(int[] bugsOnField, string input)
        {
            string[] tokens = input.Split(' ').ToArray();
            int startPosition = int.Parse(tokens[0]);
            string direction = tokens[1];
            int numOfJumps = int.Parse(tokens[2]);
            // if start position outside field - return
            if (startPosition < 0 || startPosition >= bugsOnField.Length)
            {
                return;
            }
            // if start position empty - return
            if (bugsOnField[startPosition] == 0)
            {
                return;
            }

            int newBugPosition = GetNewPosition(startPosition, direction, numOfJumps);
            bugsOnField[startPosition] = 0;
            if (newBugPosition < 0 || newBugPosition >= bugsOnField.Length)
            {
                return;
            }
            // if position is occupied
            if (bugsOnField[newBugPosition] == 1)
            {
                // find new position until position is empty
                while (bugsOnField[newBugPosition] == 1 )
                {
                    newBugPosition = GetNewPosition(newBugPosition, direction, numOfJumps);
                    if (newBugPosition < 0 || newBugPosition >= bugsOnField.Length)
                    {
                        break;
                    }
                }
                if (newBugPosition < 0 || newBugPosition >= bugsOnField.Length)
                {
                    return;
                }
                else if (bugsOnField[newBugPosition] == 0)
                {
                    bugsOnField[newBugPosition] = 1;
                }
            }
            bugsOnField[newBugPosition] = 1;
        }

        private static int GetNewPosition(int startPosition, string direction, int numOfJumps)
        {
            int newBugPosition = startPosition;
            if (direction == "right")
            {
                newBugPosition += numOfJumps;
            }
            else if (direction == "left")
            {
                newBugPosition -= numOfJumps;
            }
            return newBugPosition;
        }

        private static void PutBugsOnField(int[] bugsOnField, int[] ladybugIndexes)
        {
            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                if (ladybugIndexes[i] < 0 ||
                    ladybugIndexes[i] >= bugsOnField.Length ||
                    bugsOnField[ladybugIndexes[i]] == 1)
                {
                    continue;
                }
                else
                {
                    bugsOnField[ladybugIndexes[i]] = 1;
                }
            }
        }
    }
}
