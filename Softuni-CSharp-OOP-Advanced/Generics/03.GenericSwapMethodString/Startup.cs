
using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        int numOfInputLines = int.Parse(Console.ReadLine());
        List<Box<string>> boxList = new List<Box<string>>();
        

        for (int i = 0; i < numOfInputLines; i++)
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            boxList.Add(box);
        }

        List<int> elementsToSwap = Console.ReadLine().Split().Select(int.Parse).ToList();
        int firstElement = elementsToSwap[0];
        int secondElement = elementsToSwap[1];

        var swapper = new GenericSwapper();
        swapper.SwapElements(boxList, firstElement, secondElement);

        Console.WriteLine(string.Join(Environment.NewLine, boxList));
    }
}

