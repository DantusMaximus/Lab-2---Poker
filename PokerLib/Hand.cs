using System;
using System.Collections.Generic;
namespace Poker
{
    class Hand
    {
        List<ICard> cards;
        IPlayer player;
        public int Count { get => cards.Count; }
        public List<ICard> Cards { 
            get => cards; 
            set { 
                cards = value; 
                if(IsFull()){HandType = ScoreLogic.DetermineHandType(cards);}
            } 
        }
        public IPlayer Player { get => player; }
        public HandType HandType { get; set; }
        public Hand(IPlayer player)
        {
            if (player == null){
                throw new NullReferenceException("Nonexisting Player");
                }
            this.player = player;
            cards = new List<ICard>();
        }
        public Hand(IPlayer player, List<ICard> cards)
        {
            if(player == null || cards == null){
                throw new NullReferenceException();
                }
            this.player = player;
            this.cards = cards;
        }


        public void Add(ICard card)
        {
            if (cards.Contains(card)) { throw new Exception("Dublicate card"); }
            if (IsFull()) { 
                throw new Exception("Hand overflow"); 
                }
            cards.Add(card);
            if(IsFull()){HandType = ScoreLogic.DetermineHandType(cards);}
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