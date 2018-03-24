using System;

    class StartUp
    {
        static void Main()
        {
            var family = new Family();
            int numOfMembers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfMembers; i++)
            {
                var memberTokens = Console.ReadLine().Split();
                var name = memberTokens[0];
                var age = int.Parse(memberTokens[1]);
                var newMember = new Person(name, age);
                family.AddMember(newMember);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
