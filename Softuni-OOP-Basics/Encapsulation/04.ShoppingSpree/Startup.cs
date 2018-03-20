
using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        try
        {
            List<Person> people = GetPeople();
            List<Product> products = GetProducts();


            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] args = command.Split();
                var person = people.FirstOrDefault(x => x.Name == args[0]);
                var product = products.FirstOrDefault(x => x.Name == args[1]);

                if (person.Money < product.Cost)
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    continue;
                }


                person.Money -= product.Cost;
                person.BagOfProducts.Add(product.Name);

                Console.WriteLine($"{person.Name} bought {product.Name}");
            }


            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static List<Product> GetProducts()
    {
        List<Product> products = new List<Product>();
        string[] productsInfo = Console.ReadLine().Split(';', ' ');
        foreach (var product in productsInfo)
        {
            if (product == "")
            {
                continue;
            }
            string[] productTokens = product.Split('=');
            Product newProduct = new Product(productTokens[0], decimal.Parse(productTokens[1]));
            products.Add(newProduct);
        }

        return products;
    }

    private static List<Person> GetPeople()
    {
        List<Person> peopleList = new List<Person>();
        string[] peopleInfo = Console.ReadLine().Split(';');
        foreach (var person in peopleInfo)
        {
            string[] personTokens = person.Split('=');
            Person newPerson = new Person(personTokens[0], decimal.Parse(personTokens[1]));
            peopleList.Add(newPerson);
        }

        return peopleList;
    }
}
