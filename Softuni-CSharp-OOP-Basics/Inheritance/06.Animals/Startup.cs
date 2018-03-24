
using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ReadAndCreateAnimal(animals, animalType);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ReadAndCreateAnimal(List<Animal> animals, string animalType)
    {
        string[] tokens = Console.ReadLine().Split();
        NotEmptyValidation(tokens);
        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                animals.Add(cat);
                break;
            case "Dog":
                Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                animals.Add(dog);
                break;
            case "Frog":
                Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                animals.Add(frog);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]), tokens[2]);
                animals.Add(kitten);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
                break;
        }
    }

    private static void NotEmptyValidation(string[] tokens)
    {
        if (tokens.Length < 3)
        {
            throw new ArgumentException("Invalid input!");
        }
    }
}
