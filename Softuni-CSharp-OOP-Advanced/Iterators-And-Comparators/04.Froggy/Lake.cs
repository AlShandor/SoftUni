
using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    public T[] Stones { get; }

    public Lake(T[] stones)
    {
        this.Stones = stones;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Stones.Length; i++)
        {
            if (i % 2 == 1)
            {
                continue;
            }

            yield return this.Stones[i];
        }

        int lastIndex = this.Stones.Length % 2 == 1 ? this.Stones.Length - 2 : this.Stones.Length - 1;

        for (int j = lastIndex; j >= 0; j--)
        {
            if (j % 2 == 0)
            {
                continue;
            }

            yield return this.Stones[j];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

