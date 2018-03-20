class Startup
{
    static void Main()
    {
        var person1 = new Person();
        person1.Name = "Pesho";
        person1.Age = 20;

        var person2 = new Person
        {
            Name = "Gosho",
            Age = 18
        };

        var person3 = new Person
        {
            Name = "Stamat",
            Age = 43
        };
    }
}
