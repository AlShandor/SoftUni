﻿
using System;

public class Startup
{
    static void Main()
    {
        int numOfInputLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfInputLines; i++)
        {
            var input = int.Parse(Console.ReadLine());
            var box = new Box<int>(input);
            Console.WriteLine(box);
        }
    }
}

