namespace ChristmasPastryShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Booths;
    using Models.Booths.Contracts;
    using Models.Cocktails;
    using Models.Cocktails.Contracts;
    using Models.Delicacies;
    using Models.Delicacies.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;

            IBooth booth = new Booth(id, capacity);
            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            else if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName); 
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            else if (size != "Large" && size != "Middle" && size != "Small")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }
            else if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> availableBooths = booths
                .Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .ToList();

           availableBooths = availableBooths
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();

            IBooth booth = availableBooths.FirstOrDefault();
            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] orderTokens = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderTokens[0];
            string itemName = orderTokens[1];
            int countOfOrderedPieces = int.Parse(orderTokens[2]);
            string size = String.Empty;

            if (itemTypeName != nameof(Gingerbread)
                && itemTypeName != nameof(Stolen)
                && itemTypeName != nameof(MulledWine)
                && itemTypeName != nameof(Hibernation))
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            double amount = 0;

            if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {
                List<IDelicacy> delicacies = booth
                    .DelicacyMenu
                    .Models
                    .Where(d => d.GetType().Name == itemTypeName)
                    .ToList();

                if (!delicacies.Any() || !delicacies.Any(d => d.Name == itemName))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                IDelicacy delicacy = null;
                if (itemTypeName == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(itemName);
                }
                else if (itemTypeName == nameof(Stolen))
                {
                    delicacy = new Stolen(itemName);
                }

                amount = delicacy.Price * countOfOrderedPieces;
            }
            else if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                size = orderTokens[3];

                List<ICocktail> cocktails = booth
                    .CocktailMenu
                    .Models
                    .Where(d => d.GetType().Name == itemTypeName)
                    .ToList();

                if (!cocktails.Any() || !cocktails.Any(c => c.Name == itemName))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                else if (!cocktails.Any(c => c.Name == itemName && c.Size == size))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                ICocktail cocktail = null;
                if (itemTypeName == nameof(MulledWine))
                {
                    cocktail = new MulledWine(itemName, size);
                }
                else if (itemTypeName == nameof(Hibernation))
                {
                    cocktail = new Hibernation(itemName, size);
                }

                amount = cocktail.Price * countOfOrderedPieces;
            }

            booth.UpdateCurrentBill(amount);

            return String.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:F2} lv");

            booth.Charge();
            booth.ChangeStatus();

            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }
    }
}
