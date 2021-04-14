using System;
using System.Collections.Generic;

namespace AllCardsOnDeckCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program Description:

            // Creates a new deck of cards.
            // Shuffles deck Fisher–Yates style.
            // Displays the top two cards.

            // The deck contains 52 unique cards.
            // All cards are represented as as a string such as "Ace of Hearts".
            // There are four suits: "Clubs", "Diamonds", "Hearts", and "Spades".
            // There are 13 ranks: "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", and "King".

            // Create the deck as a List of strings.
            var deck = new List<string>();

            // Create an array of suits.
            var suit = new string[] { " of Spades", " of Hearts", " of Clubs", " of Diamonds" };

            // Iterate through the suits, concatenating the ranks. Then add the full string to the deck.
            for (int suitCount = 0; suitCount < 4; suitCount++) // Increment through the 4 suits.
            {
                for (int cardCount = 1; cardCount < 12; cardCount++) // Increment through the ranks.
                {
                    if (cardCount == 1) // Make the first card an Ace.
                    {
                        deck.Add("Ace" + suit[suitCount].ToString());
                    }
                    else if (cardCount >= 2 && cardCount <= 10) // Make 2-10 their normal values.
                    {
                        deck.Add(cardCount.ToString() + suit[suitCount].ToString());
                    }
                    else if (cardCount == 11) // Once we reach the face cards, just Add them to the deck.
                    {
                        deck.Add("Jack" + suit[suitCount].ToString());
                        deck.Add("Queen" + suit[suitCount].ToString());
                        deck.Add("King" + suit[suitCount].ToString());
                    }
                }
            }

            // Length of our deck. 
            var numberOfCards = deck.Count;

            // Be a cool kid and do the Fisher–Yates shuffle!
            for (var i = numberOfCards - 1; i >= 0; i--) // Start at the end of the List and decrement.
            {
                var somePlace = new Random().Next(0, i); // Generate a random number.

                var rightCard = deck[i]; // Copy the card from the end of the List.

                deck[i] = deck[somePlace]; // Change the card at the end of the List to some other random card to its left. 

                deck[somePlace] = rightCard; // That random card's old spot is now replaced with our copied card.
            }

            // Display the top two cards.
            // Adventure mode... 
            // In addition to displaying the top two cards, 
            // also store these two "dealt" cards in a variable named playerHand.
            // Implement a way to deal cards into two different hands.
            var playerHand = new List<string>();
            var playerFoot = new List<string>();

            // Display cards as dealt. 
            for (int twoCards = 0; twoCards < 4; twoCards++)
            {
                Console.WriteLine($"Player One: {deck[twoCards]}");
                playerHand.Add(deck[twoCards]);
                twoCards++;

                Console.WriteLine($"Player Two: {deck[twoCards]}");
                playerFoot.Add(deck[twoCards]);
            }

            Console.WriteLine();

            // Display hands separately. 
            Console.WriteLine("Player One's Hand:");
            foreach (var card in playerHand)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("Player Two's Hand:");
            foreach (var card in playerFoot)
            {
                Console.WriteLine(card);
            }
        }
    }
}
