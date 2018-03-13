using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int lengthOfSequence = int.Parse(Console.ReadLine());

        long[] sequence = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();
        

        while (true)
        {
            string line = Console.ReadLine().Trim();
            string[] stringParams = line.Split(ArgumentsDelimiter);
            string command = stringParams[0];
            if (command == "stop")
            {
                break;
            }

            int[] arguments = new int[2];
            if (command.Equals("add") || command.Equals("subtract") || command.Equals("multiply"))
            {
                arguments[0] = int.Parse(stringParams[1]);
                arguments[1] = int.Parse(stringParams[2]);
                sequence = PerformCommand(sequence, command, arguments);
            }
            else if (command.Equals("lshift"))
            {
                sequence = ArrayShiftLeft(sequence);
            }
            else if (command.Equals("rshift"))
            {
                sequence = ArrayShiftRight(sequence);
            }

            PrintArray(sequence);
        }
    }

    static long[] PerformCommand(long[] arr, string command, int[] arguments)
    {
        long[] array = arr.Clone() as long[];
        int position = arguments[0] - 1;
        int value = arguments[1];

        switch (command)
        {
            case "multiply":
                array[position] *= value;
                break;
            case "add":
                array[position] += value;
                break;
            case "subtract":
                array[position] -= value;
                break;
        }
        return array;
    }

    private static long[] ArrayShiftRight(long[] array)
    {
        long firstNum = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = firstNum;
        return array;
    }

    private static long[] ArrayShiftLeft(long[] array)
    {
        long lastNum = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = lastNum;
        return array;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
