using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name) => Drinks.Remove(Drinks.FirstOrDefault(x => x.Name == name));

        public Drink GetLongest() => Drinks.MaxBy(d => d.Volume);

        public Drink GetCheapest() => Drinks.MinBy(d => d.Price);

        public string BuyDrink(string name) => Drinks.FirstOrDefault(d => d.Name == name).ToString();

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");

            Drinks.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().Trim();
        }
    }
}
