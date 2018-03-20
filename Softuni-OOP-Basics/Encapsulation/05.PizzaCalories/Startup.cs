
using System;

class Startup
{
    static void Main()
    {
        try
        {
            string[] pizzaTokens = Console.ReadLine().Split();
            Pizza pizza = new Pizza(pizzaTokens[1]);

            string[] doughTokens = Console.ReadLine().Split();
            Dough dough = new Dough(doughTokens[1], doughTokens[2], int.Parse(doughTokens[3]));
            pizza.Dough = dough;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingTokens = command.Split();
                Topping newTopping = new Topping(toppingTokens[1], int.Parse(toppingTokens[2]));
                pizza.AddTopping(newTopping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
