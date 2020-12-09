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
            hand = SortByRankAndSuite(hand);
            if (IsRoyalStraightFlush(hand)) { return HandType.RoyalStraightFlush; }
            if (IsStraightFlush(hand)) { return HandType.StraightFlush; }
            if (IsFourOfAKind(hand)) { return HandType.FourOfAKind; }
            if (IsFullHouse(hand)) { return HandType.FullHouse; }
            if (IsFlush(hand)) { return HandType.Flush; }
            if (IsStraight(hand)) { return HandType.Straight; }
            if (IsThreeOfAKind(hand)) { return HandType.ThreeOfAKind; }
            if (IsTwoPair(hand)) { return HandType.TwoPairs; }
            if (IsPair(hand)) { return HandType.Pair; }
            return HandType.HighCard;
        }
        private static bool IsRoyalStraightFlush(List<ICard> hand)
        {
            if (IsStraightFlush(hand) && hand[0].Rank == Rank.Ten) { return true; }
            return false;
        }
        private static bool IsStraightFlush(List<ICard> hand)
        {
            if (IsFlush(hand) && IsStraight(hand)) { return true; }
            return false;
        }
        private static bool IsFourOfAKind(List<ICard> hand)
        {
            return IsAmmountOfMost(4, hand);
        }

        private static bool IsFullHouse(List<ICard> hand)
        {
            if (!IsThreeOfAKind(hand))
            {
                return false;
            }
            if (hand[0].Rank != hand[1].Rank) { return false; }
            if (hand[3].Rank != hand[4].Rank) { return false; }
            return true;
        }

        private static bool IsFlush(List<ICard> hand)
        {
            if (hand.FindAll(h => h.Suite == hand[0].Suite).Count() == 5)
            {
                return true;
            }
            return false;
        }

        private static bool IsStraight(List<ICard> hand)
        {
            if (isIncrementalByOne(5)) { 
                return true; }  

            if (hand[4].Rank != Rank.Ace) { 
                return false; 
            }   
            if( hand[0].Rank != Rank.Two) {
                return false; 
            } 

            if (isIncrementalByOne(4)) { 
                return true; 
                } 

            return false;

            bool isIncrementalByOne(int ammount)
            {
                for (int i = 0; i < ammount-1; i++)
                {
                    if ((int)hand[i+1].Rank != ((int)hand[i].Rank) + 1) { return false; }
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
            //First pair
            if (!IsPair(tempHand)) { return false; }
            Rank mostPop = MostPopularCard(tempHand);

            //Remove first pair
            tempHand.RemoveAll(card => card.Rank == mostPop);

            //Second pair
            if (!IsPair(tempHand)) { return false; }
            return true;
        }

        private static bool IsPair(List<ICard> hand)
        {
            return IsAmmountOfMost(2, hand);
        }

        public static List<IPlayer> DetermineWinners(List<IPlayer> players)
        {
        
            var highHand = GetHighestHandType(players);
            List<IPlayer> highestPlayers = players.FindAll(player => player.HandType == highHand);
         
            if (highestPlayers.Count() == 1)
            {              
                return new List<IPlayer>(){highestPlayers[0]};
            } 

            List<Hand> highestHands = new  List<Hand>();
            foreach(Player player in highestPlayers){
                highestHands.Add(player.hand);
            }
            highestHands = SortByPointCards( highestHands);

            for (int i = 0; i < 5; i++)
            {
                var highRank = highestHands.OrderBy(hand => hand.Cards[i].Rank).Last().Cards[i].Rank;
                highestHands.RemoveAll(hand => hand.Cards[i].Rank != highRank);
            }

            List<IPlayer> winners = new List<IPlayer>();

            foreach (Hand hand in highestHands)
            {
                winners.Add(hand.Player);
            }
            return winners;
        }



        private static HandType GetHighestHandType(List<IPlayer> player)
        {
            return player.OrderBy(player => player.HandType).Last().HandType;
        }
        public static List<ICard> SortByRankAndSuite(List<ICard> cards)
        {           
            var query = cards.OrderBy(card => (int)card.Rank);
            cards = new List<ICard>();
            foreach (ICard card in query)
            {
                cards.Add(card);
            }

            return cards;
        }
        private static Rank MostPopularCard(List<ICard> cards)
        {
            Rank mostPop = (from l in cards
                            group l by l.Rank into gr
                            orderby gr.Count() descending
                            select gr.Key).First();
            return mostPop;
        }
        private static bool IsAmmountOfMost(int ammount, List<ICard> cards)
        {
            Rank mostPop = MostPopularCard(cards);
            int amountOfMost = cards.FindAll(cards => cards.Rank == mostPop).Count();
            if (amountOfMost == ammount) { return true; }
            return false;
        }

        private static List<Hand> SortByPointCards(List<Hand> hands)
        {
            List<Hand> result = new List<Hand>();
            foreach (Hand hand in hands)
            {
                result.Add(SortByPointCards(hand));
            }
            return result;
        }

        private static Hand SortByPointCards(Hand hand)
        {
            var sorting = hand.HandType;
            List<ICard> cards = hand.Cards;
            cards.Reverse();
            switch (sorting)
            {

                case HandType.RoyalStraightFlush:
                    {
                        //already sorted for scenario
                        break;
                    }
                case HandType.StraightFlush:
                    {
                        StraightCase();
                        break;
                    }
                case HandType.FourOfAKind:
                    {
                        cards = OrderByPopThenRank();
                        break;
                    }

                case HandType.FullHouse:
                    {
                        cards = OrderByPopThenRank();
                        break;
                    }

                case HandType.Flush:
                    {
                        //already sorted for scenario
                        break;
                    }

                case HandType.Straight:
                    {
                        StraightCase();
                        break;
                    }
                case HandType.ThreeOfAKind:
                    {
                        cards = OrderByPopThenRank();
                        break;

                    }
                case HandType.TwoPairs:
                    {
                        List<ICard> pair = TakeAndRemove(MostPopularCard(cards));
                        List<ICard> otherPair = TakeAndRemove(MostPopularCard(cards));
                        ICard loneCard = TakeAndRemove(MostPopularCard(cards))[0];

                        if (pair[0].Rank > otherPair[0].Rank)
                        {
                            cards.AddRange(pair);
                            cards.AddRange(otherPair);
                        }
                        else
                        {
                            cards.AddRange(otherPair);
                            cards.AddRange(pair);
                        }

                        cards.Add(loneCard);
                        break;

                    }
                case HandType.Pair:
                    {
                        cards = OrderByPopThenRank();
                        break;
                    }
                case HandType.HighCard:
                    {                 
                        break;
                    }
            }
            String handRanks = "";
            foreach (Card card in hand.Cards)
            {
                handRanks += card.Rank;
            }

            return new Hand(hand.Player, cards);

            void StraightCase()
            {
                if (cards[0].Rank == Rank.Ace)
                {
                    ICard ace = cards[0];
                    cards.Remove(ace);
                    cards.Add(ace);
                }
            }
            List<ICard> TakeAndRemove(Rank rank)
            {
                List<ICard> relevantCards = cards.FindAll(card => card.Rank == rank);
                cards.RemoveAll(card => card.Rank == rank);
                return relevantCards;
            }
            List<ICard> OrderByPopThenRank()
            {
                Rank popRank = MostPopularCard(cards);
                List<ICard> pair = cards.FindAll(card => card.Rank == popRank);
                List<ICard> rest = cards.FindAll(card => card.Rank != popRank);
                cards = new List<ICard>();
                cards.AddRange(pair);
                cards.AddRange(rest);
                return cards;
            }

        }

    }
}