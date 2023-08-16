namespace Cards
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> cardFaces = new List<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            Dictionary<string, string> codeByCardSuit = new Dictionary<string, string>()
            {
                { "S", "\u2660" },
                { "H", "\u2665" },
                { "D", "\u2666" },
                { "C", "\u2663" },
            };

            List<Card> cards = new List<Card>();

            string[] cardsInput = Console.ReadLine()
                .Split(", ");

            foreach (string card in cardsInput)
            {
                string[] cardTokens = card.Split(' ');
                string face = cardTokens[0];
                string suit = cardTokens[1];

                try
                {
                    if (!cardFaces.Contains(face) || !codeByCardSuit.ContainsKey(suit))
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    Card currentCard = new Card(face, codeByCardSuit[suit]);
                    cards.Add(currentCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }
    }

    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
