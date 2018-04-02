using System.Collections.Generic;

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            string xName = x.Name.ToLower();
            string yName = y.Name.ToLower();
            result = xName[0].CompareTo(yName[0]);
        }

        return result;
    }
}

