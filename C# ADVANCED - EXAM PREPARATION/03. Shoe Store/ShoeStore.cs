using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore;

public class ShoeStore
{
    public ShoeStore(string name, int storageCapacity)
    {
        Name = name;
        StorageCapacity = storageCapacity;
        Shoes = new List<Shoe>();
    }

    public string Name { get; set; }
    public int StorageCapacity { get; set; }
    public List<Shoe> Shoes { get; set; }

    public int Count => Shoes.Count;

    public string AddShoe(Shoe shoe)
    {
        if (Shoes.Count < StorageCapacity)
        {
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        else
        {
            return "No more space in the storage room.";
        }
    }

    public int RemoveShoes(string material)
    {
        var removedShoes = Shoes.RemoveAll(x => x.Material == material);
        return removedShoes;
    }

    public List<Shoe> GetShoesByType(string type)
    {
        List<Shoe> shoesOfOneType = Shoes.FindAll(x => x.Type == type.ToLower());

        return shoesOfOneType;
    }

    public Shoe GetShoeBySize(double size)
    {
        Shoe searchedShoe = Shoes.Where(sh => sh.Size == size).FirstOrDefault();
        return searchedShoe;
    }

    public string StockList(double size, string type)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Stock list for size {size} - {type} shoes:");

        bool isFound = false;

        foreach (var shoe in Shoes)
        {
            if (shoe.Type == type && shoe.Size == size)
            {
                sb.AppendLine(shoe.ToString());
                isFound = true;
            }
        }

        if (isFound)
        {
            return sb.ToString().Trim();
        }

        return "No matches found!";
    }
}
