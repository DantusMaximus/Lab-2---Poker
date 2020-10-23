using System;
namespace Poker.Lib
{
    class ScoreLogic
    {

        static HandType SetHandType(ICard[] inputHand)
        {
            List<Icard> hand = inputHand;
            hand = sortByRankAndSuite(hand);
            return new NotImplementedException();
        }
        static IPlayer[] DetermineWinners(List<IPlayer> winners)
        {
            return new NotImplementedException();
        }

        private static HandType GetHighestHandType(IPlayer[] players)
        {
            return new NotImplementedException();
        }

        private static void sortByRankAndSuite(List<Icard> hand)
        {
            hand.OrderBy(card => card.rank);
            return new NotImplementedException();
        }


    }
}