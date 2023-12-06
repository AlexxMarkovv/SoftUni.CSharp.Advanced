using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniKindergarten;

public class Kindergarten
{
    public Kindergarten(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        Registry = new List<Child>();
    }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public List<Child> Registry { get; set; }

    public int ChildrenCount { get { return Registry.Count; } }

    public bool AddChild(Child child)
    {
        bool isAdded = false;

        if (Registry.Count < Capacity)
        {
            Registry.Add(child);
            isAdded = true;
        }
        return isAdded;
    }

    public bool RemoveChild(string childFullName)
    {
        bool isRemoved = false;
        Child childS = null;

        childS = Registry.Find(x => x.FirstName + " " + x.LastName == childFullName);

        return isRemoved = Registry.Remove(childS);
    }

    public Child GetChild(string childFullName)
    {
        Child child = null;

        child = Registry.Find(x => x.FirstName + " " + x.LastName == childFullName);

        return child;
    }

    public string RegistryReport()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Registered children in {Name}:").ToString().Trim();

        foreach (var child in Registry
            .OrderByDescending(x => x.Age)
            .ThenBy(x => x.LastName)
            .ThenBy(x => x.FirstName))
        {
            stringBuilder.AppendLine(child.ToString().Trim());
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
