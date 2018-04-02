using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        var nameComparer = new PersonNameComparer();
        var ageComparer = new PersonAgeComparer();

        SortedSet<Person> nameSet = new SortedSet<Person>(nameComparer);
        SortedSet<Person> ageSet = new SortedSet<Person>(ageComparer);

        int numPersons = int.Parse(Console.ReadLine());
        for (int i = 0; i < numPersons; i++)
        {
            string[] personArgs = Console.ReadLine().Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            var person = new Person(name, age);

            nameSet.Add(person);
            ageSet.Add(person);
        }

        foreach (var person in nameSet)
        {
            Console.WriteLine(person);
        }

        foreach (var person in ageSet)
        {
            Console.WriteLine(person);
        }
    }
}

