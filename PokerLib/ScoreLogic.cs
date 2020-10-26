using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class ScoreLogic
    {

        static public HandType DetermineHandType(List<ICard> inputHand)
        {
            var hand = new List<ICard>(inputHand);
            SortByRankAndSuite(hand);
            //TODO: ROYAL STRAIGHT FLUSH
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
        private static bool IsRoyalStraightFlush(List<ICard> hand)
        {
            if(IsStraightFlush(hand) && hand[0].Rank == Rank.Ten){ return true;}
            return false;
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

        public static List<IPlayer> DetermineWinners(List<IPlayer> players)
        {
            List<Hand> hands = new List<Hand>();
            List<IPlayer> winners = new List<IPlayer>();
            foreach(Player player in players){
                hands.Add(player.hand);
            }

            var highHand = GetHighestHandType(hands);
            System.Console.WriteLine("highest handtype is: " + highHand);
            List<Hand> highestHands = hands.FindAll(hand => hand.HandType == highHand);

            if(highestHands.Count() == 1){
                winners.Add(highestHands[0].Player);
                return winners;
            }
            
            highestHands = SortByPointCards(highestHands);
            
            for(int i = 0; i <4; i++){

                Rank highRank = Rank.Two;
                foreach(Hand hand in highestHands){
                    if (hand.Cards[i].Rank > highRank){
                        highRank = hand.Cards[i].Rank;
                    }
                }

                Hand indexWinner = highestHands.OrderBy(hand => hand.Cards[i].Rank).Last();
                highRank = indexWinner.Cards[i].Rank;
                highestHands.RemoveAll(hand => hand.Cards[i].Rank != highRank);
            }
            winners = new List<IPlayer>();
            
            foreach(Hand hand in highestHands){
                winners.Add(hand.Player);
            }
            return winners;

            throw new System.NotImplementedException();
        }

    

        private static HandType GetHighestHandType(List<Hand> hands)
        {
           return hands.Select(hand => hand.HandType).Max();
        }
        //TODO: test
        public static List<ICard> SortByRankAndSuite(List<ICard> cards)
        {                      
            var query = cards.OrderBy(card => (int)card.Suite);
            query = cards.OrderBy(card => (int)card.Rank);     
            cards = new List<ICard>();
            foreach(ICard card in query){
                cards.Add(card);
            }
           
            return cards;       
        }
        private static Rank MostPopularCard(List<ICard> cards){
            Rank mostPop = (from l in cards
                         group l by l.Rank into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return mostPop;
        }
        private static bool IsAmmountOfMost(int ammount,List<ICard> cards ){
            Rank mostPop = MostPopularCard(cards);
            int amountOfMost = cards.Select(cards => cards.Rank == mostPop).Count();
            if(amountOfMost == ammount){return true;}
            return false;
        }

          private static List<Hand> SortByPointCards(List<Hand> hands)
        {
            List<Hand> result = new List<Hand>();
            foreach(Hand hand in hands){
                result.Add(SortByPointCards(hand));
            }
            return result;
        }

          private static Hand SortByPointCards(Hand hand)
        {
            var sorting = hand.HandType;
            List<ICard> cards = hand.Cards;
            cards.Reverse();

            switch(sorting){
                
                case HandType.RoyalStraightFlush:

                
                break;

                case HandType.StraightFlush:
                {
                    if (cards[4].Rank != Rank.Ace)
                    {
                        break;
                    }
                    ICard temp = cards[4];
                    cards[4] = cards[0];
                    cards[0] = temp;

                    break;
                }
                case HandType.FourOfAKind:
                {
                Rank popRank = MostPopularCard(cards);
                List<ICard> fourOfAKind = cards.FindAll(card =>card.Rank == popRank);
                var rest = cards.FindAll(card => card.Rank != popRank);
                cards = fourOfAKind;
                cards.AddRange(rest);
                 break;
                }

                case HandType.FullHouse:
                {
                Rank popRank = MostPopularCard(cards);
                var threes = cards.FindAll(card =>card.Rank == popRank);
                var twoes = cards.FindAll(card =>card.Rank != popRank);
                cards = threes;
                cards.AddRange(twoes);
                 break;           
                }

                case HandType.Flush:
                {
                 break;
                }

                case HandType.Straight:
                {
                    if (cards[4].Rank != Rank.Ace){
                        break;
                    }
                    if(cards[3].Rank != Rank.King){
                    ICard temp = cards[4];
                    cards[4] = cards[0];
                    cards[0] = temp;
                    }
                 break;
                }
                case HandType.ThreeOfAKind:
                {
                    Rank popRank = MostPopularCard(cards);
                    List<ICard> threes = cards.FindAll(card => card.Rank == popRank);
                    List<ICard> rest = cards.FindAll(card => card.Rank != popRank);
                    cards = threes;
                    cards.AddRange(rest);
                 break;
                }
                case HandType.TwoPairs:
                {
                    Rank popRank = MostPopularCard(cards);
                    List<ICard> pair = cards.FindAll(card => card.Rank == popRank);
                    List<ICard> rest = cards.FindAll(card =>card.Rank != popRank);
                    
                    Rank otherPopRank = MostPopularCard(cards);
                    List<ICard> otherPair = cards.FindAll(card => card.Rank == otherPopRank);
                    rest = cards.FindAll(card =>card.Rank != popRank);

                    cards = new List<ICard>();
                    if(popRank > otherPopRank){
                        cards.AddRange(pair);
                        cards.AddRange(otherPair);
                    }else{
                        cards.AddRange(otherPair);
                        cards.AddRange(pair);   
                    }
                    cards.AddRange(rest);
                    
                 break;
                 }
                case HandType.Pair:        
                {
                    Rank popRank = MostPopularCard(cards);
                    List<ICard> pair = cards.FindAll(card => card.Rank == popRank);
                    List<ICard> rest = cards.FindAll(card =>card.Rank != popRank);
                    rest = (List<ICard>)rest.OrderBy(card => card.Rank);
                    cards = new List<ICard>();
                    cards.AddRange(pair);
                    cards.AddRange(rest);
                    break;
                } 
                case HandType.HighCard:
                
                    cards.OrderBy(Card => Card.Rank);
                 break;

                
            }
            String handRanks = "";
            foreach(Card card in hand.Cards){
                handRanks += card.Rank;
            }

            System.Console.WriteLine("type is " + sorting + " and card ranks are: " + cards);
            return new Hand(hand.Player, cards);
        }

}
}