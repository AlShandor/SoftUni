
using System;
using System.Collections;
using System.Collections.Generic;


public class Stack<T> : IEnumerable<T>
{
    public List<T> Collection { get; private set; }

    public Stack()
    {
        this.Collection = new List<T>();
    }

    public void Push(List<T> elements)
    {
        foreach (var element in elements)
        {
            this.Collection.Add(element);
        }
    }

    public void Pop()
    {
        if (this.Collection.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        this.Collection.RemoveAt(this.Collection.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Collection.Count - 1; i >= 0; i--)
        {
            yield return this.Collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

