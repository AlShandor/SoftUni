
using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        List<Person> familyTree = new List<Person>();

        string personToPrint = Console.ReadLine();
        Person newPerson = new Person() { Name = personToPrint };
        familyTree.Add(newPerson);

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            // person birthDay
            if (!input.Contains("-"))
            {
                AddPersonsBirthday(input, familyTree);
            }
            // parent child
            else
            {
                AddParentChildConnection(input, familyTree);
            }
        }
        
        // connect children to parents
        foreach (var person in familyTree)
        {
            // find each person their parents
            if (familyTree.Any(x => x.Children.Any(y => y.Name == person.Name || y.Birthday == person.Birthday)))
            {
                var parents = familyTree.FindAll((x => x.Children.Any(y => y.Name == person.Name || y.Birthday == person.Birthday)));
                foreach (var parent in parents)
                {
                    if (person.Parents.Any(x => x.Name == parent.Name || x.Birthday == parent.Name))
                    {
                        continue;
                    }
                    person.Parents.Add(parent);
                }
            }


            // find each person their children
            if (familyTree.Any(x => x.Parents.Any(y => y.Name == person.Name || y.Birthday == person.Birthday)))
            {
                var children = familyTree.FindAll((x => x.Parents.Any(y => y.Name == person.Name || y.Birthday == person.Birthday)));
                foreach (var child in children)
                {
                    if (person.Children.Any(x => x.Name == child.Name || x.Birthday == child.Birthday))
                    {
                        continue;
                    }
                    person.Children.Add(child);
                }
            }
        }

        PrintPersonFamilyTree(personToPrint, familyTree);
    }

    private static void PrintPersonFamilyTree(string personToPrint, List<Person> familyTree)
    {
        Person person = familyTree.Find(x => x.Name == personToPrint);
        Console.WriteLine($"{person.Name} {person.Birthday}");
        Console.WriteLine("Parents:");
        foreach (var parent in person.Parents)
        {
            Console.WriteLine($"{parent.Name} {parent.Birthday}");
        }

        Console.WriteLine("Children:");
        foreach (var child in person.Children)
        {
            Console.WriteLine($"{child.Name} {child.Birthday}");
        }
    }

    private static void AddParentChildConnection(string input, List<Person> familyTree)
    {
        string[] parentAndChild = input.Split('-').Select(x => x.Trim()).ToArray();

        CreatePersonIfNotInFamilyTree(parentAndChild[0], familyTree);
        CreatePersonIfNotInFamilyTree(parentAndChild[1], familyTree);

        //find parent and add to family tree
        Person parent = FindPersonInFamilyTree(familyTree, parentAndChild[0]);

        //find child and add to family tree
        Person child = FindPersonInFamilyTree(familyTree, parentAndChild[1]);

        //fill in their connection
        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    private static void CreatePersonIfNotInFamilyTree(string personNameOrDate, List<Person> familyTree)
    {
        if (familyTree.Any(x => x.Name == personNameOrDate || x.Birthday == personNameOrDate))
        {
            return;
        }

        Person newPerson = new Person();

        if (personNameOrDate.Contains("/"))
        {
            newPerson.Birthday = personNameOrDate;
        }
        else
        {
            newPerson.Name = personNameOrDate;
        }

        familyTree.Add(newPerson);
    }

    private static Person FindPersonInFamilyTree(List<Person> familyTree, string nameOrDate)
    {
        Person person = new Person();

        if (familyTree.Exists(x => x.Birthday == nameOrDate))
        {
            person = familyTree.Find(x => x.Birthday == nameOrDate);
        }

        if (familyTree.Exists(x => x.Name == nameOrDate))
        {
            person = familyTree.Find(x => x.Name == nameOrDate);
        }

        return person;
    }

    private static void AddPersonsBirthday(string input, List<Person> familyTree)
    {
        string[] personNameAndBirthday = input.Split();
        string personName = personNameAndBirthday[0] + " " + personNameAndBirthday[1];
        string birthday = personNameAndBirthday[2];


        //check if there is person with that name and add date
        if (familyTree.Any(x => x.Name == personName))
        {
            var personWithThatName = familyTree.Find(x => x.Name == personName);
            personWithThatName.Birthday = birthday;
        }
        //else check if there is person with that date and add name
        else if (familyTree.Any(x => x.Birthday == birthday))
        {
            var personWithThatDate = familyTree.Find(x => x.Birthday == birthday);
            personWithThatDate.Name = personName;
        }
        // if no such person create him
        else
        {
            Person newPerson = new Person();
            newPerson.Name = personName;
            newPerson.Birthday = birthday;
            familyTree.Add(newPerson);
        }
    }
}
