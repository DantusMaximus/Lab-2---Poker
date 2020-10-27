using System;
using System.Collections.Generic;
namespace Poker
{
    class Hand
    {
        List<ICard> cards;
        IPlayer player;
        public int Count { get => cards.Count; }
        public int MaxCardAmmount { get; set; }
        public List<ICard> Cards { get => cards; set { cards = value; } }
        public IPlayer Player { get => player; }
        public HandType HandType { get; set; }
        public Hand(IPlayer player)
        {
            this.player = player;
            cards = new List<ICard>();
        }
        public Hand(IPlayer player, List<ICard> cards)
        {
            this.player = player;
            this.cards = cards;
        }

        public Hand Clone(){
            return new Hand(player, cards);
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
    }
}