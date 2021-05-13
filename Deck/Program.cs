using System;
using System.Collections.Generic;

namespace Deck
{
    // I included this as one file because it's easier to attach to an Email. If this was an actually project I'd extract out both the Deck.cs and Card.cs so that we have our classes
    //contained in their own files. This was done for simplicity's sake.

    // Creating a card class makes it easier to track, since it allows us to think of both the deck and the card as seperate objects.
    // If we were using these cards for a game I'd also add two more props like a RankPower as an integer so we could use simple int to int comparisions to see which is
    // is better say a play draws a 10 and the computer draws a Jack. It's easier to compare a 10 to an 11 and abstract the value away from the user.
    class Card
    {
        public Card(string rank, string suit)
        {
             Rank = rank;
             Suit = suit;
        }
        public string Rank { get; set; }
        public string Suit { get; set; }

    }

    // I wanted to make the deck it's own class because it's easier to think of as an object/collection made up as cards but it also has it's own unique functions
    // I hard coded the list/collection of cards since we know that this is a standard deck. IF we were making different styles of decks, I'd do something different. 
    class Deck
    {
            List<Card> Cards = new List<Card>()
            {
                // All Ranks in Hearts
                new Card("Ace", "Hearts"), new Card("2", "Hearts"), new Card("3", "Hearts"), new Card("4", "Hearts"),new Card("5", "Hearts"),
                new Card("6", "Hearts"),new Card("7", "Hearts"),new Card("8", "Hearts"),new Card("9", "Hearts"),new Card("10", "Hearts"),
                new Card("Jack", "Hearts"),new Card("Queen", "Hearts"),new Card("King", "Hearts"),
                // All Ranks in Diamonds
                new Card("Ace", "Diamonds"), new Card("2", "Diamonds"), new Card("3", "Diamonds"), new Card("4", "Diamonds"),new Card("5", "Diamonds"),
                new Card("6", "Diamonds"),new Card("7", "Diamonds"),new Card("8", "Diamonds"),new Card("9", "Diamonds"),new Card("10", "Diamonds"),
                new Card("Jack", "Diamonds"),new Card("Queen", "Diamonds"),new Card("King", "Diamonds"),
                // All Ranks in Clubs
                new Card("Ace", "Clubs"), new Card("2", "Clubs"), new Card("3", "Clubs"), new Card("4", "Clubs"),new Card("5", "Clubs"),
                new Card("6", "Clubs"),new Card("7", "Clubs"),new Card("8", "Clubs"),new Card("9", "Clubs"),new Card("10", "Clubs"),
                new Card("Jack", "Clubs"),new Card("Queen", "Clubs"),new Card("King", "Clubs"),
                // All Ranks in Spades
                new Card("Ace", "Spades"), new Card("2", "Spades"), new Card("3", "Spades"), new Card("4", "Spades"),new Card("5", "Spades"),
                new Card("6", "Spades"),new Card("7", "Spades"),new Card("8", "Spades"),new Card("9", "Spades"),new Card("10", "Spades"),
                new Card("Jack", "Spades"),new Card("Queen", "Spades"),new Card("King", "Spades"),
            };

        public void Shuffle()
        {
        // This is based off the Fisher-Yates shuffle algorithm which you can read about here: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        Random rng = new Random();
        // This will count how many cards we have to shuffle.
        int cardsToBeShuffled = Cards.Count;
            // We are going to loop while cards to be shuffled are greater than 1 because we're 0 indexed.
            while (cardsToBeShuffled > 1)
            {
                // First make sure that we increment our tracker
                cardsToBeShuffled--;
                // Next we make a random index, this is the card we're giong to grab and shuffle
                int cardBeingShuffledIndex = rng.Next(cardsToBeShuffled + 1);
                // Next we grab the actual Card object at the index being shuffled. To store it for the last step
                Card shuffledCard = Cards[cardBeingShuffledIndex];
                // Next we assign the value of the Card at the cardsToBeShuffled index.
                Cards[cardBeingShuffledIndex] = Cards[cardsToBeShuffled];
                // Then we use the shuffledCard obj to insert it back into the Cards list/Deck
                Cards[cardsToBeShuffled] = shuffledCard;  
            }
        }

        public Card DrawOneCard() {
            // I'm "drawing" a card off the "bottom" of the deck. If the deck was face down on the table I think of the bottom as the first
            // face down card. 

            // We're checking to see if the deck has anymore cards left to draw.
            if (Cards.Count > 0)
            {
                // If we have cards left we execute this block.

                // First we grab the card and store it in a value. This is simply to allow use to print to the console. Which is done with the user in mind.
                Card draw = Cards[Cards.Count - 1];

                // This simulates the action of taking a card from the deck. The deck has a finite amount of cards, so we remove the card that is drawn from the deck/cards.
                Cards.RemoveAt(Cards.Count - 1);

                //This is for the user, if you run this file in your terminal using dotnet run [FILE NAME].cs --- this will print out what is happening.
                Console.WriteLine($"You drew: a {draw.Rank} of {draw.Suit}");

                // This is the important part. We're returning the card object. This could be used to build a player's hand, a class that might contain a list of cards that
                // the player drew.
                return draw;
            }

            // These two lines make it clear to the user or programmer what is happening. If you're null checking properly this will tip you off that you need a new deck.
            // While also writing to the console in plain english what has happened. I chose this over a try/catch block
            Console.WriteLine("You have drawn all the cards");
            return null;
        }

        // This is a bonus method, I didn't feel like writing 53 DrawOneCard calls so I made a method that checks how many cards are left
        // and draws all of them. This method will not over draw the deck.
        public void DrawAllCards()
        {
            int totalCards = Cards.Count - 1;
            for (int i = 0; i <= totalCards; i++)
            {
                DrawOneCard();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            deck.DrawOneCard();
            deck.DrawOneCard();
            deck.DrawAllCards();
            deck.DrawOneCard();

        }
    }
}
