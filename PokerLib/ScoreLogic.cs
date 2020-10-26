using System.Collections.Generic;
using System.Linq;
namespace Poker
{
    class ScoreLogic
    {

        static HandType DetermineHandType(List<ICard> inputHand)
        {
            var hand = new List<ICard>(inputHand);
            hand = SortByRankAndSuite(hand);
            if(IsStraightFlush(hand))    { return HandType.StraightFlush;}
            if(IsFourOfAKind(hand))      { return HandType.FourOfAKind;}
            if(IsFullHouse(hand))        { return HandType.FullHouse;}
            if(IsFlush(hand))            { return HandType.Flush;}
            if(IsStraight(hand))         { return HandType.Straight;}
            if(IsThreeOfAKind(hand))     { return HandType.ThreeOfAKind;}
            if(IsTwoPair(hand))          { return HandType.TwoPairs;}
            if(IsPair(hand))             { return HandType.Pair;}
            return HandType.HighCard;
        }
        private static bool IsStraightFlush(List<ICard> hand)
        {
            if(IsFlush(hand) && IsFlush(hand)){ return true;}
            return false;
        }
        private static bool IsFourOfAKind(List<ICard> hand)
        {
            return IsAmmountOfMost(4, hand);
        }

        private static bool IsFullHouse(List<ICard> hand)
        {
            if(!IsThreeOfAKind(hand)){
                return false;
            }
            if(hand[0].Rank != hand[1].Rank ){ return false;}
            if(hand[3].Rank != hand[4].Rank ){ return false;}
            return true;            
        }

        private static bool IsFlush(List<ICard> hand)
        {
            if(hand.Select(h => h.Suite == hand[0].Suite).Count() == 5){ return true;}
            return false;
        }

        private static bool IsStraight(List<ICard> hand)
        {   
            if(isIncrementalByOne(4)){return true;}
            
            if( hand[4].Rank != Rank.Ace) {return false;}
            if(isIncrementalByOne(3)){ return true;}
            return false;            

            bool isIncrementalByOne(int LastIndexToCheck){
                for(int i = 0; i < LastIndexToCheck -1; i++){
                    if(hand[i+1].Rank == hand[i].Rank + 1 ){return false;}                    
                }   
                return true;
            }
        }

        private static bool IsThreeOfAKind(List<ICard> hand)
        {
            return IsAmmountOfMost(3, hand);
        }

        private static bool IsTwoPair(List<ICard> hand)
        {
            var tempHand = new List<ICard>(hand);
            //first pair
            if(!IsPair(tempHand)){ return false;}
            Rank mostPop = MostPopularCard(tempHand);

            //remove first pair
            tempHand.RemoveAll(card => card.Rank == mostPop);

            //second pair
            if(!IsPair(tempHand)){ return false;}
            return true;           
        }

        private static bool IsPair(List<ICard> hand)
        {
            return IsAmmountOfMost(2, hand);
        }

        static IPlayer[] DetermineWinners(List<IPlayer> winners)
        {
            throw new System.NotImplementedException();
        }

        private static HandType GetHighestHandType(IPlayer[] players)
        {
            throw new System.NotImplementedException();
        }
        //TODO: test
        private static List<ICard> SortByRankAndSuite(List<ICard> hand)
        {            
            hand.OrderBy(card => card.Suite);
            hand.OrderBy(card => card.Rank);
            return hand;
        }
        private static Rank MostPopularCard(List<ICard> hand){
            Rank mostPop = (from l in hand
                         group l by l.Rank into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return mostPop;
        }
        private static bool IsAmmountOfMost(int ammount,List<ICard> hand ){
            Rank mostPop = MostPopularCard(hand);
            int amountOfMost = hand.Select(hand => hand.Rank == mostPop).Count();
            if(amountOfMost == ammount){return true;}
            return false;
        }
}
}