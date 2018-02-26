using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> que = new Queue<long>();
            Queue<long> que2 = new Queue<long>();
            que.Enqueue(num);

            for (int i = 0; i < 50; i++)
            {
                que.Enqueue(que.Peek() + 1);
                que.Enqueue((que.Peek()) * 2 + 1);
                que.Enqueue(que.Peek() + 2);
                que2.Enqueue(que.Dequeue());
            }

            Console.WriteLine(string.Join(" ", que2));
        }
    }
}
