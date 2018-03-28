using System;
using System.Collections.Generic;
using System.Linq;


class Startup
{
    static void Main()
    {
        var familyTree = new List<Person>();

        string personInput = Console.ReadLine();
        //Person mainPerson = new Person(personInput);
        //familyTree.Add(mainPerson);

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" - ");
            // parent child relation
            if (tokens.Length > 1)
            {
                string parent = tokens[0];
                string child = tokens[1];

                Person parentPerson;

                // set parentPerson child
                bool isBirthday = IsBirthday(parent);
                if (isBirthday)
                {
                    parentPerson = familyTree.FirstOrDefault(p => p.Birthday == parent);
                }
                else
                {
                    parentPerson = familyTree.FirstOrDefault(p => p.Name == parent);
                }

                if (parentPerson == null)
                {
                    parentPerson = CreateNewPersonIfNotExist(familyTree, parent, parentPerson, isBirthday);
                }


                SetChildParentRelation(familyTree, parentPerson, child);

            }
            // person birthday
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                if (person == null)
                {
                    person = new Person();
                    familyTree.Add(person);
                }
                else if (familyTree.Any(p => p.Name == name))
                {
                    person = familyTree.FirstOrDefault(p => p.Name == name);
                    person.Birthday = birthday;
                }
                else if (familyTree.Any(p => p.Birthday == birthday))
                {
                    person = familyTree.FirstOrDefault(p => p.Birthday == birthday);
                    person.Name = name;
                }

                //int indexCurrentPerson = familyTree.IndexOf(person) + 1;
                //int count = familyTree.Count - indexCurrentPerson;

                //Person[] copy = new Person[count];
                //familyTree.CopyTo(indexCurrentPerson, copy, 0, count);

                //Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                //if (copyPerson != null)
                //{
                //    familyTree.Remove(copyPerson);
                //    person.Parents.AddRange(copyPerson.Parents);
                //    person.Parents = person.Parents.Distinct().ToList();

                //    person.Children.AddRange(copyPerson.Children);
                //    person.Children = person.Children.Distinct().ToList();
                //}
            }
        }

        PrintMainPersonFamilyTree(familyTree.Where(x => x.Name == personInput || x.Birthday == personInput).First());
    }

    private static Person CreateNewPersonIfNotExist(List<Person> familyTree, string firstPerson, Person currentPerson, bool isBirthday)
    {
        currentPerson = new Person();
        if (isBirthday)
        {
            currentPerson.Birthday = firstPerson;
        }
        else
        {
            currentPerson.Name = firstPerson;
        }

        familyTree.Add(currentPerson);

        return currentPerson;
    }

    private static void PrintMainPersonFamilyTree(Person mainPerson)
    {
        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        foreach (var p in mainPerson.Parents)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("Children:");
        foreach (var c in mainPerson.Children)
        {
            Console.WriteLine(c);
        }
    }

    private static void SetChildParentRelation(List<Person> familyTree, Person parentPerson, string child)
    {
        Person childPerson;
        bool existChildInFamilyTree = true;
        // find (create) child
        if (IsBirthday(child))
        {
            // if child not exist create it
            if (!familyTree.Any(p => p.Birthday == child))
            {
                childPerson = new Person();
                childPerson.Birthday = child;
                existChildInFamilyTree = false;
            }
            // reference existing child
            else
            {
                childPerson = familyTree.First(p => p.Birthday == child);
            }
        }
        else
        {
            if (!familyTree.Any(p => p.Name == child))
            {
                childPerson = new Person();
                childPerson.Name = child;
                existChildInFamilyTree = false;
            }
            else
            {
                childPerson = familyTree.First(p => p.Name == child);
            }
        }

        // TODO something here
        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(parentPerson);

        // if child did not exist add it, else don't
        if (!existChildInFamilyTree)
        {
            familyTree.Add(childPerson);
        }
        
    }

    static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }
}
