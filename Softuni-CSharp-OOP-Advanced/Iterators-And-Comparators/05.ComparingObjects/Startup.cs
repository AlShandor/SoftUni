using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        var people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] personArgs = input.Split();
            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);
            string town = personArgs[2];
            var person = new Person(name, age, town);
            people.Add(person);
        }

        int indexOfPersonToCompare = int.Parse(Console.ReadLine());
        var personToCompare = people[indexOfPersonToCompare - 1];
        people.RemoveAt(indexOfPersonToCompare - 1);

        int numEqualPeople = 1;
        int numNotEqualPeople = 0;

        foreach (var person in people)
        {
            if (personToCompare.CompareTo(person) == 0)
            {
                numEqualPeople++;
            }
            else
            {
                numNotEqualPeople++;
            }
        }

        if (numEqualPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{numEqualPeople} {numNotEqualPeople} {numEqualPeople + numNotEqualPeople}");
        }
    }
}

