using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new Dictionary<string, Stock>();

        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Dictionary<string, Stock> Portfolio;

        public int Count { get => Portfolio.Count; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && stock.PricePerShare <= this.MoneyToInvest)
            {
                this.Portfolio.Add(stock.CompanyName, stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (Portfolio[companyName].PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.MoneyToInvest += sellPrice;
                this.Portfolio.Remove(companyName);

                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            if (Portfolio.ContainsKey(companyName))
            {
                return Portfolio[companyName];
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            if (!Portfolio.Any())
            {
                return null;
            }

            Dictionary<string, Stock> sortedStocks = this.Portfolio.OrderByDescending(x => x.Value.MarketCapitalization).ToDictionary(x => x.Key, x => x.Value);

            return sortedStocks.FirstOrDefault().Value;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (Stock stock in Portfolio.Values)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
