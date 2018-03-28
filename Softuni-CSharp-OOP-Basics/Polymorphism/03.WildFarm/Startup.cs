
using System;
using System.Collections.Generic;

public class Startup
{
    

    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        FoodFactory foodFactory = new FoodFactory();
        AnimalFactory animalFactory = new AnimalFactory();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalTokens = input.Split();
            Animal animal = animalFactory.GetAnimal(animalTokens[0], animalTokens);

            string[] foodTokens = Console.ReadLine().Split();
            Food food = foodFactory.GetFood(foodTokens[0], int.Parse(foodTokens[1]));

            Console.WriteLine(animal.ProduceSound());

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

