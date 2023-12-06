using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators;

public class Catalog
{
    private List<Renovator> renovators;
    public Catalog(string name, int neededRenovators, string project)
    {
        Name = name;
        NeededRenovators = neededRenovators;
        Project = project;
        Renovators = new List<Renovator>();
    }

    public List<Renovator> Renovators
    {
        get { return renovators; }
        set { renovators = value; }
    }

    public string Name { get; set; }
    public int NeededRenovators { get; set; }
    public string Project { get; set; }

    public int Count { get { return Renovators.Count; } }

    public string AddRenovator (Renovator renovator)
    {
        if (renovator.Name == null || renovator.Type == null)
        {
            return "Invalid renovator's information.";
        }
        else if (Renovators.Count >= NeededRenovators)
        {
            return "Renovators are no more needed.";
        }
        else if (renovator.Rate > 350)
        {
            return "Invalid renovator's rate.";
        }
        else
        {
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
    }

    public bool RemoveRenovator(string name)
    {
        bool isExists = false;

        for (int i = 0; i < renovators.Count; i++)
        {
            if (renovators[i].Name == name)
            {
                renovators.Remove(renovators[i]);
                isExists = true;
                break;
            }
            else
            {
                isExists = false;
                break;
            }
        }

        return isExists;
    }

    public int RemoveRenovatorBySpecialty(string type)
    {
        int count = 0;

        for (int i = 0; i < renovators.Count; i++)
        {
            if (renovators[i].Type == type)
            {
                renovators.Remove(renovators[i]);
                count++;
            }
        }

        return count;
    }

    public Renovator HireRenovator(string name)
    {
        for (int i = 0; i < renovators.Count; i++)
        {
            if (renovators[i].Name == name)
            {
                renovators[i].Hired = true;
                return renovators[i];
            }
        }

        return null;
    }

    public List<Renovator> PayRenovators(int days)
    {
        List<Renovator> payRentrs = new List<Renovator>();

        for (int i = 0; i < renovators.Count; i++)
        {
            if (renovators[i].Days >= days)
            {
                payRentrs.Add(renovators[i]);
            }
        }

        return payRentrs;
    }

    public string Report()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Renovators available for Project {Project}:");

        foreach (var item in renovators.Where(x => x.Hired == false))
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString().Trim();
    }
}
