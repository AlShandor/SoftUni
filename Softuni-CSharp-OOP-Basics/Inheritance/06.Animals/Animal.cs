
using System;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "Sound!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{GetType().Name}");
        sb.AppendLine($"{name} {age} {gender}");
        sb.AppendLine($"{ProduceSound()}");

        return sb.ToString().TrimEnd();
    }
}