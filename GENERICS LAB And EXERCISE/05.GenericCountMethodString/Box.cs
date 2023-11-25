using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString;

public class Box<T> where T : IComparable<T>
{
    private List<T> list;

    public Box()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public int CountElementsGreaterThanValue(T value)
    {
        int count = 0;
        foreach (T item in list)
        {
            if (value.CompareTo(item) == -1)
            {
                count++;
            }
        }
        return count;
    }

}
