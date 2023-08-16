using System;

namespace DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int termOfDeposit = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());
            double accruedInterest = depositSum * annualInterestRate / 100;
            double annualInterestPerMonth = accruedInterest / 12;
            double totalSum = depositSum + termOfDeposit * annualInterestPerMonth;
            Console.WriteLine(totalSum);
        }
    }
}
