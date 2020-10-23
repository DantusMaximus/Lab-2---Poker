using System;
namespace Poker.Lib
{
    class Hand{
        List<Icard> cards;
        Hand(IPlayer player){
            this.cards = player.Hand;
        }

        IPlayer Player{get;}
        List<ICard> Hand{ get; set;}
        HandType HandType{ get; set; }
        
    }
}