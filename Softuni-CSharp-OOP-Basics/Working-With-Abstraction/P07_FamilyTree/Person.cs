using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public Person(string personInput)
    {
        parents = new List<Person>();
        children = new List<Person>();
        if (IsBirthday(personInput))
        {
            Birthday = personInput;
        }
        else
        {
            Name = personInput;
        }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public List<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Person> Children
    {
        get { return children; }
        set { children = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }

    public static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }
}
