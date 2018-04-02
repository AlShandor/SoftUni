
using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    public List<T> List { get; }

    public int CurrentIndex { get; private set; }

    public ListyIterator()
    {
        this.List = new List<T>();
        this.CurrentIndex = 0;
    }

    public ListyIterator(List<T> collection) : this()
    {
        this.List = collection;
    }

    public bool Move()
    {
        if (this.CurrentIndex + 1 == List.Count)
        {
            return false;
        }
        this.CurrentIndex++;
        return true;
    }

    public bool HasNext()
    {
        if (this.CurrentIndex + 1 == List.Count)
        {
            return false;
        }
        return true;
    }

    public void Print()
    {
        if (this.List.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.List[this.CurrentIndex]);
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ", this.List));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.List.Count; i++)
        {
            yield return this.List[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

