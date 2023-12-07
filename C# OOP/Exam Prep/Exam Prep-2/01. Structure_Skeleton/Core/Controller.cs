using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            booths = new BoothRepository();
        }

        private BoothRepository booths;

        public string AddBooth(int capacity)
        {
            var booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return $"Added booth number {booth.BoothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if(size != "Large" && size != "Middle" && size != "Small")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            var booth = booths.Models.First(b => b.BoothId == boothId);

            var cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Size == size && c.Name == cocktailName);
            
            if (cocktail != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Stolen" && delicacyTypeName != "Gingerbread")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            var booth = booths.Models.First(b => b.BoothId == boothId);
            var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (delicacy != null)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {

            var booth = booths.Models.First(b => b.BoothId == boothId);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();

            booth.ChangeStatus();

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            booth.ChangeStatus();

            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {

            string[] currentOrder = order.Split("/").ToArray();

            string itemTypeName = currentOrder[0];
            string itemName = currentOrder[1];
            int countOfOrderedPieces = int.Parse(currentOrder[2]);
            var size = string.Empty;

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                size = currentOrder[3];
            }

            var booth = booths.Models.First(b => b.BoothId == boothId);

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return $"There is no {size} {itemName} available!";
                }

                var cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(countOfOrderedPieces * cocktail.Price);

                return $"Booth {boothId} ordered {countOfOrderedPieces} {itemName}!";
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    return $"There is no { itemTypeName } { itemName} available!";
                }

                var delicacy = booth.DelicacyMenu.Models.First(d => d.Name == itemName);


                if (delicacy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                booth.UpdateCurrentBill(countOfOrderedPieces * delicacy.Price);

                return $"Booth {boothId} ordered {countOfOrderedPieces} {itemName}!";
            }
        }
    }
}
