using System;
using System.Collections.Generic;
namespace Poker
{
    class Hand
    {
        List<ICard> cards;
        IPlayer player;
        public int Count { get; set; }
        public int MaxCardAmmount { get; set; }
        public Hand(IPlayer player)
        {
            this.player = player;
            cards = new List<ICard>();
        }
        public Hand(IPlayer player, List<ICard> cards)
        {

        }
        public void Add(ICard card)
        {
            if (cards.Contains(card)) { throw new System.Exception("Dublicate card"); }
            if (IsFull()) { throw new System.Exception("Hand overflow"); }
            cards.Add(card);
        }

        public bool Contains(ICard disc)
        {
            return cards.Contains(disc);
        }

        public void Remove(ICard disc)
        {
            cards.Remove(disc);
        }

        public bool IsFull()
        {
            return cards.Count == 5;
        }
        public List<ICard> Cards { get => cards; set { cards = value; } }
        IPlayer Player { get; }
        HandType HandType { get; set; }

    }
}