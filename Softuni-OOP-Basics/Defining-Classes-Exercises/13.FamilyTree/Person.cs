
using System.Collections.Generic;

public class Person
{
    private string name;
    private string birthday;

    public List<Person> Parents = new List<Person>();
    public List<Person> Children = new List<Person>();
    
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
}
