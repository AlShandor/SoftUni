
using System.Collections.Generic;
using System;

public class Smartphone : IInternetBrowsable, ICallable
{
    private List<string> phoneNumbers;
    private List<string> websites;

    public List<string> PhoneNumbers
    {
        get { return phoneNumbers; }
        private set { phoneNumbers = value; }
    }

    public List<string> Websites
    {
        get { return websites; }
        private set { websites = value; }
    }

    public void AddPhoneNumbers(List<string> phoneNumbers)
    {
        PhoneNumbers = new List<string>();
        PhoneNumbers.AddRange(phoneNumbers);
    }

    public void AddWebsites(List<string> websites)
    {
        Websites = new List<string>();
        Websites.AddRange(websites);
    }

    public string CallNumber(string phoneNumber)
    {
        if (!IsPhoneNumberValid(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}";
    }

    public string BrowseWebsite(string url)
    {
        if (!IsURLValid(url))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {url}!";
    }

    private bool IsURLValid(string url)
    {
        bool isValid = true;
        foreach (char c in url)
        {
            if (char.IsDigit(c))
            {
                isValid = false;
            }
        }

        return isValid;
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        bool isValid = true;
        foreach (char c in phoneNumber)
        {
            if (!char.IsDigit(c))
            {
                isValid = false;
            }
        }

        return isValid;
    }
}


