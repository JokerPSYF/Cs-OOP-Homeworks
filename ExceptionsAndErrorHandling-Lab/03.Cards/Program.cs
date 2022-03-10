using System;
using System.Collections.Generic;

namespace _03.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardInfo = input[i].Split();
                try
                {
                    Card card = new Card(cardInfo[0], cardInfo[1]);
                    cards.Add(card);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }

    public class Card
    {
        private string face;

        private string suit;

        public string Face
        {
            get => face;
            set
            {
                switch (value)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                    case "A":
                        face = value;
                        break;

                    default:
                        throw new ArgumentException("Invalid card!");
                }
            }
        }

        public string Suit
        {
            get => suit;
            set
            {
                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;

                    case "H":
                        suit = "\u2665";
                        break;

                    case "D":
                        suit = "\u2666";
                        break;

                    case "C":
                        suit = "\u2663";
                        break;

                    default:
                        throw new ArgumentException("Invalid card!");
                }
            }
        }

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString() => $"[{face}{suit}]";
    }
}