using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Cheese – 500 calories
// Tomato sauce – 150 calories
// Salami – 600 calories
// Pepper – 50 calories
//If you receive one of these ingredients more than once, you should add the calories to the total amount again.You
//should not process any other ingredients. Ingredients are case-insensitive.
namespace _08.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfIngredients = int.Parse(Console.ReadLine());
            string ingredient = "";
            string cheese = "cheese";
            string tomatoSauce = "tomato sauce";
            string salami = "salami";
            string pepper = "pepper";
            int totalCaloriesAmount = 0;

            for (int i = 1; i <= numberOfIngredients; i++)
            {
                ingredient = Console.ReadLine();
                ingredient = ingredient.ToLower();
                if (ingredient == cheese)
                {
                    totalCaloriesAmount += 500;
                }
                else if (ingredient == tomatoSauce)
                {
                    totalCaloriesAmount += 150;
                }
                else if (ingredient == salami)
                {
                    totalCaloriesAmount += 600;
                }
                else if (ingredient == pepper)
                {
                    totalCaloriesAmount += 50;
                }
                else
                {
                    totalCaloriesAmount += 0;
                }
            }
            Console.WriteLine($"Total calories: {totalCaloriesAmount}");
        }
    }
}
