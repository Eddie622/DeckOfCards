using System;
using System.Collections.Generic;

namespace DeckofCards
{
    class Card
    {
        public string stringVal { get; }
        public string suit { get; }
        public int val { get; }

        public Card(string stringValArg, string suitArg, int valArg)
        {
            stringVal = stringValArg;
            suit = suitArg;
            val = valArg;
        }
    }
    class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = MakeDeck();
        }

        public Card RemoveTop()
        {
            var temp = this.cards[0];
            this.cards.RemoveAt(0);
            return temp;
        }

        public void Reset()
        {
            this.cards = MakeDeck();
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for(int i = 0; i < this.cards.Count; i++)
            {   
                int randInt = rand.Next(this.cards.Count);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[randInt];
                this.cards[randInt] = temp;
            }
        }

        public List<Card> MakeDeck()
        {
            List<Card> NewDeck = new List<Card>();

            for (int i = 1; i <= 52; i++)
            {
                if (i <= 13)
                {
                    switch (i % 13)
                    {
                        case 1:
                            NewDeck.Add(new Card("Ace", "Clubs", i));
                            break;
                        case 11:
                            NewDeck.Add(new Card("Jack", "Clubs", i));
                            break;
                        case 12:
                            NewDeck.Add(new Card("Queen", "Clubs", i));
                            break;
                        case 0:
                            NewDeck.Add(new Card("King", "Clubs", i));
                            break;
                        default:
                            NewDeck.Add(new Card(i.ToString(), "Clubs", i));
                            break;
                    }
                }
                else if (i <= 26)
                {
                    switch (i % 13)
                    {
                        case 1:
                            NewDeck.Add(new Card("Ace", "Spades", i - 13));
                            break;
                        case 11:
                            NewDeck.Add(new Card("Jack", "Spades", i - 13));
                            break;
                        case 12:
                            NewDeck.Add(new Card("Queen", "Spades", i - 13));
                            break;
                        case 0:
                            NewDeck.Add(new Card("King", "Spades", i - 13));
                            break;
                        default:
                            NewDeck.Add(new Card((i - 13).ToString(), "Spades", i - 13));
                            break;
                    }
                }
                else if (i <= 39)
                {
                    switch (i % 13)
                    {
                        case 1:
                            NewDeck.Add(new Card("Ace", "Hearts", i - 26));
                            break;
                        case 11:
                            NewDeck.Add(new Card("Jack", "Hearts", i - 26));
                            break;
                        case 12:
                            NewDeck.Add(new Card("Queen", "Hearts", i - 26));
                            break;
                        case 0:
                            NewDeck.Add(new Card("King", "Hearts", i - 26));
                            break;
                        default:
                            NewDeck.Add(new Card((i - 26).ToString(), "Hearts", i - 26));
                            break;
                    }
                }
                else
                {
                    switch (i % 13)
                    {
                        case 1:
                            NewDeck.Add(new Card("Ace", "Diamonds", i - 39));
                            break;
                        case 11:
                            NewDeck.Add(new Card("Jack", "Diamonds", i - 39));
                            break;
                        case 12:
                            NewDeck.Add(new Card("Queen", "Diamonds", i - 39));
                            break;
                        case 0:
                            NewDeck.Add(new Card("King", "Diamonds", i - 39));
                            break;
                        default:
                            NewDeck.Add(new Card((i - 39).ToString(), "Diamonds", i - 39));
                            break;
                    }
                }
            }
            return NewDeck;
        }
        class Player
        {
            public String name;
            public List<Card> PlayerHand = new List<Card>();
            public Player(String nameArg = "Guest")
            {
                name = nameArg;
            }

            public Card Draw(Deck DeckArg)
            {
                Card temp = DeckArg.RemoveTop();
                this.PlayerHand.Add(temp);
                return temp;
            }

            public Card Discard(int indexVal)
            {
                if(indexVal - 1 > this.PlayerHand.Count || indexVal - 1 < 0)
                {
                    return null;
                } 
                
                var temp = this.PlayerHand[indexVal-1];
                this.PlayerHand.RemoveAt(indexVal-1);
                return temp;
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Deck MyDeck = new Deck();
                Player MyPlayer = new Player();

                // Console.WriteLine(MyDeck.cards.Count);
                // foreach (var CardEntry in MyDeck.cards)
                // {
                //     Console.WriteLine($"StringVal = {CardEntry.stringVal}, Suit = {CardEntry.suit}, Val = {CardEntry.val}");
                // }

                MyDeck.Shuffle();

                Console.WriteLine(MyPlayer.name);
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));
                Console.WriteLine(MyPlayer.Draw(MyDeck));

                foreach(var cardEntry in MyPlayer.PlayerHand)
                {
                    Console.WriteLine(cardEntry.val);
                }

                Console.WriteLine(MyDeck.cards.Count);

                Console.WriteLine(MyPlayer.Discard(0));
                Console.WriteLine(MyPlayer.Discard(1));
                Console.WriteLine(MyPlayer.Discard(11));
                foreach(var cardEntry in MyPlayer.PlayerHand)
                {
                    Console.WriteLine(cardEntry.val);
                }
            }
        }
    }
}

