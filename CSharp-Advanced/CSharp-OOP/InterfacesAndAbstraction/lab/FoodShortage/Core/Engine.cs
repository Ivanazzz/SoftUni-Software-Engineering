namespace FoodShortage.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private ICollection<IBuyer> buyers;

        private Engine()
        {
            buyers = new HashSet<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreateBuyers();

            BuyFood();

            PrintTotalAmountOfPurchasedFood();
        }

        private void CreateBuyers()
        {
            int lines = int.Parse(reader.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = reader
                    .ReadLine()
                    .Split();

                IBuyer buyer = null;
                if (cmdArgs.Length == 4)
                {
                    string citizenName = cmdArgs[0];
                    int citizenAge = int.Parse(cmdArgs[1]);
                    string citizenID = cmdArgs[2];
                    string citizenBirthdate = cmdArgs[3];

                    buyer = new Citizen(citizenName, citizenAge, citizenID, citizenBirthdate);
                }
                else
                {
                    string rebelName = cmdArgs[0];
                    int rebelAge = int.Parse(cmdArgs[1]);
                    string rebelGroup = cmdArgs[2];

                    buyer = new Rebel(rebelName, rebelAge, rebelGroup);
                }

                buyers.Add(buyer);
            }
        }

        private void BuyFood()
        {
            string name;
            while ((name = reader.ReadLine()) != "End")
            {
                IBuyer currentBuyer = buyers.FirstOrDefault(b => b.Name == name);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }
        }

        private void PrintTotalAmountOfPurchasedFood()
        {
            int totalAmountOfPurchasedFood = buyers.Sum(b => b.Food);

            writer.WriteLine(totalAmountOfPurchasedFood.ToString());
        }
    }
}
