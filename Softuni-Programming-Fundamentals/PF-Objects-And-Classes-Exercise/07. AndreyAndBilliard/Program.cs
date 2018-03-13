using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numOfProducts = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> productsPrices = GetProductPrices(numOfProducts);
            List<Customer> listOfCustomer = new List<Customer>();

            string inputClients = Console.ReadLine();
            while (inputClients != "end of clients")
            {
                string customerName = inputClients.Split('-').First();
                string productBought = inputClients.Split(new char[] { '-', ',' }).Skip(1).First();
                if (!productsPrices.ContainsKey(productBought))
                {
                    inputClients = Console.ReadLine();
                    continue;
                }
                int productQuantity = int.Parse(inputClients.Split(new char[] { '-', ',' }).Skip(2).First());

                Customer newClient = GetNewClient(customerName, productBought, productQuantity, productsPrices);
                bool isNewCustomer = true;
                foreach (var customer in listOfCustomer)
                {
                    if (customer.Name == newClient.Name)
                    {
                        customer.Bill += newClient.Bill;
                        isNewCustomer = false;
                    }
                }

                if (isNewCustomer)
                {
                    listOfCustomer.Add(newClient);
                }
                inputClients = Console.ReadLine();
            }
            PrintCustomersBills(listOfCustomer);
        }
        
        private static void PrintCustomersBills(List<Customer> listOfCustomers)
        {
            listOfCustomers = listOfCustomers.OrderBy(c => c.Name).ToList();
            foreach (var client in listOfCustomers)
            {
                Console.WriteLine(client.Name);
                foreach (var item in client.ShoppingList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {client.Bill:f2}");
            }

            decimal totalBill = 0;
            foreach (var client in listOfCustomers)
            {
                totalBill += client.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }

        private static Customer GetNewClient(
            string clientName, string productBought, int productQuantity, Dictionary<string, decimal> productsPrices)
        {
            Customer newClient = new Customer();
            newClient.Name = clientName;
            newClient.ShoppingList[productBought] = productQuantity;
            newClient.Bill += productQuantity * productsPrices[productBought];
            return newClient;
        }

        private static Dictionary<string, decimal> GetProductPrices(int numOfProducts)
        {
            var productsPrices = new Dictionary<string, decimal>();
            for (int currentProduct = 0; currentProduct < numOfProducts; currentProduct++)
            {
                string[] productTokens = Console.ReadLine().Split('-').ToArray();
                string productName = productTokens[0];
                decimal productPrice = decimal.Parse(productTokens[1]);
                if (!productsPrices.ContainsKey(productName))
                {
                    productsPrices.Add(productName, productPrice);
                }
                else
                {
                    productsPrices[productName] = productPrice;
                }
            }
            return productsPrices;
        }

        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> ShoppingList = new Dictionary<string, int>();
            public decimal Bill { get; set; }
        }
    }
}
