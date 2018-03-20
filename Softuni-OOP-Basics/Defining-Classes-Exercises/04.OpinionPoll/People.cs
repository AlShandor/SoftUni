using System.Collections.Generic;
using System.Linq;

class People
{
    private List<Person> peopleList;

    public List<Person> PeopleList = new List<Person>();

    public void AddPersonToPeople(Person person)
    {
        PeopleList.Add(person);
    }

    public List<Person> GetPeopleAbove30Alphabetical()
    {
        var peopleAbove30Alphabetical = PeopleList.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList();
        return peopleAbove30Alphabetical;
    }
}
