using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;

            this.Clothes = new List<Cloth>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count < this.Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = this.Clothes.FirstOrDefault(x => x.Color == color);

            bool isRvemod = this.Clothes.Remove(cloth);

            return isRvemod;
        }

        public Cloth GetSmallestCloth() => this.Clothes.OrderBy(x => x.Size).FirstOrDefault();

        public Cloth GetCloth(string color) => this.Clothes.FirstOrDefault(x => x.Color == color);

        public int GetClothCount() => this.Clothes.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains:");

            foreach(var item in this.Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
