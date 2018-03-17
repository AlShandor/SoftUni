
using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Smartphone smartphone = new Smartphone();
        List<string> phoneNumbers = Console.ReadLine().Split().ToList();
        List<string> websites = Console.ReadLine().Split().ToList();

        smartphone.AddPhoneNumbers(phoneNumbers);
        smartphone.AddWebsites(websites);

        CallNumbers(smartphone);
        BrowseWebsites(smartphone);
    }

    private static void BrowseWebsites(Smartphone smartphone)
    {
        foreach (var website in smartphone.Websites)
        {
            try
            {
                Console.WriteLine(smartphone.BrowseWebsite(website));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    private static void CallNumbers(Smartphone smartphone)
    {
        foreach (var phoneNumber in smartphone.PhoneNumbers)
        {
            try
            {
                Console.WriteLine(smartphone.CallNumber(phoneNumber));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

