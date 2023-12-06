
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(c => c.Color == color);
            bool isRemoved = Clothes.Remove(cloth);

            return isRemoved;
        }

        public Cloth GetSmallestCloth() =>
            Clothes.OrderBy(x => x.Size)
                   .FirstOrDefault();

        public Cloth GetCloth(string color)
        {
            Cloth cloth = null;

            cloth = Clothes.FirstOrDefault(c => c.Color == color);

            return cloth;
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains: ");

            foreach (var item in Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(item.ToString());
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
