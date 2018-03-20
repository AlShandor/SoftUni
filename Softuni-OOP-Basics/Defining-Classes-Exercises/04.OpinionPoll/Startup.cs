using System;


class Startup
{
    static void Main()
    {
        int numOfPeople = int.Parse(Console.ReadLine());
        var people = new People();
        for (int i = 0; i < numOfPeople; i++)
        {
            var peopleTokens = Console.ReadLine().Split();
            var name = peopleTokens[0];
            var age = int.Parse(peopleTokens[1]);
            var newPerson = new Person(name, age);
            people.AddPersonToPeople(newPerson);
        }

        var peopleAbove30 = people.GetPeopleAbove30Alphabetical();
        foreach (var person in peopleAbove30)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
