namespace MoneyTransactions
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> balanceByAccount = new Dictionary<int, double>();

            string[] input = Console.ReadLine().Split(',');

            foreach (string item in input)
            {
                string[] tokens = item.Split('-');
                int account = int.Parse(tokens[0]);
                double balance = double.Parse(tokens[1]);

                balanceByAccount.Add(account, balance);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');
                string action = cmdArgs[0];
                int account = int.Parse(cmdArgs[1]);

                try
                {
                    switch (action)
                    {
                        case "Deposit":
                            if (!balanceByAccount.ContainsKey(account))
                            {
                                throw new KeyNotFoundException("Invalid account!");
                            }

                            double sum = double.Parse(cmdArgs[2]);
                            balanceByAccount[account] += sum;
                            break;
                        case "Withdraw":
                            if (!balanceByAccount.ContainsKey(account))
                            {
                                throw new KeyNotFoundException("Invalid account!");
                            }

                            double sumWithdraw = double.Parse(cmdArgs[2]);
                            if (sumWithdraw > balanceByAccount[account])
                            {
                                throw new ArgumentException("Insufficient balance!");
                            }

                            balanceByAccount[account] -= sumWithdraw;
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }

                    Console.WriteLine($"Account {account} has new balance: {balanceByAccount[account]:f2}");
                }
                catch (KeyNotFoundException knfe)
                {
                    Console.WriteLine(knfe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
