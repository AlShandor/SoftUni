
using System.Collections.Generic;

public class GenericSwapper
{
    public void SwapElements(List<Box<int>> collection, int firstElement, int secondElement)
    {
        var temp = collection[firstElement];
        collection[firstElement] = collection[secondElement];
        collection[secondElement] = temp;
    }
}

