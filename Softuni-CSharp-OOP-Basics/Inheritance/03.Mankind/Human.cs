
using System;

class Human
{
    private const int MIN_FIRST_NAME_LENGTH = 4;
    private const int MIN_LAST_NAME_LENGTH = 3;

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < MIN_FIRST_NAME_LENGTH)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < MIN_LAST_NAME_LENGTH)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }
            lastName = value;
        }
    }
    
}

