using System.Collections.Generic;
using System.Linq;

public class Family
{
    private HashSet<Person> familyMembers;

    public HashSet<Person> FamilyMembers = new HashSet<Person>();

    public void AddMember(Person member)
    {
        FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        var oldestMember = FamilyMembers.OrderByDescending(x => x.Age).First();

        return oldestMember;
    }
}
