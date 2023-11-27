using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString;

public class Box<T>
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

 
    public List<T> SwapElements(int firstIndex, int secondIndex)
    {
        T firstItem = list.ElementAt(firstIndex);
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = firstItem;

        //(list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);

        return list;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (T item in list)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }
        
        return sb.ToString().TrimEnd();
    }
}
