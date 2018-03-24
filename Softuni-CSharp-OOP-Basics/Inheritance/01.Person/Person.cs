
using System;
using System.Text;

public class Person
{
    private const int MIN_AGE = 0;
    private const int MIN_NAME_LENGTH = 3;
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get { return this.age; }
        set
        {
            if (value < MIN_AGE)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("Name: {0}, Age: {1}",
            this.Name,
            this.Age));

        return sb.ToString();
    }
}
