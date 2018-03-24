
using System;

public class Child : Person
{
    private const int MAX_AGE = 15;

    public Child(string name, int age) : base(name, age)
    {
    }

    public override int Age
    {
        set
        {
            if (value > MAX_AGE)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }

}
