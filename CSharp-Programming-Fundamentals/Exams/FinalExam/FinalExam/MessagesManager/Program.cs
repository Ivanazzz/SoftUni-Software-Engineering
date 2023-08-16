using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacityOfPossibleMessagesPerUser = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> messages = new Dictionary<string, List<int>>();
            List<string> namesOrder = new List<string>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Statistics")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "Add":
                        string usernameToAdd = tokens[1];
                        int sentMessages = int.Parse(tokens[2]);
                        int receivedMessages = int.Parse(tokens[3]);

                        if (!messages.ContainsKey(usernameToAdd))
                        {
                            messages.Add(usernameToAdd, new List<int> { sentMessages, receivedMessages });
                            namesOrder.Add(usernameToAdd);
                        }
                        break;
                    case "Message":
                        string sender = tokens[1];
                        string receiver = tokens[2];

                        if (messages.ContainsKey(sender) && messages.ContainsKey(receiver))
                        {
                            messages[sender][0]++;
                            messages[receiver][1]++;

                            int totalNumberOfMessagesBySender = messages[sender].Sum();
                            int totalNumberOfMessagesByReceiver = messages[receiver].Sum();

                            if (totalNumberOfMessagesBySender == capacityOfPossibleMessagesPerUser)
                            {
                                messages.Remove(sender);
                                namesOrder.Remove(sender);
                                Console.WriteLine($"{sender} reached the capacity!");

                                if (totalNumberOfMessagesByReceiver == capacityOfPossibleMessagesPerUser)
                                {
                                    messages.Remove(receiver);
                                    namesOrder.Remove(receiver);
                                    Console.WriteLine($"{receiver} reached the capacity!");
                                }
                            }
                            else if (totalNumberOfMessagesByReceiver == capacityOfPossibleMessagesPerUser)
                            {
                                messages.Remove(receiver);
                                namesOrder.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                        break;
                    case "Empty":
                        string username = tokens[1];

                        if (username == "All")
                        {
                            messages.Clear();
                            namesOrder.Clear();
                        }
                        else
                        {
                            messages.Remove(username);
                            namesOrder.Remove(username);
                        }
                        break;
                }
            }

            Console.WriteLine($"Users count: {messages.Count}");
            foreach (var user in namesOrder)
            {
                Console.WriteLine($"{user} - {messages[user].Sum()}");
            }
        }
    }
}
