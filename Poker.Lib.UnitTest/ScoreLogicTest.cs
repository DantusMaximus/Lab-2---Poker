using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class ScoreLogicTest
    {
        static public int[][] allValidPositionCombos = allPositionCombinations();
        static private int[][] allPositionCombinations()
        {
           
            List<int[]> theList = new List<int[]>();
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        for (int d = 0; d < 5; d++)
                        {
                            for (int e = 0; e < 5; e++)
                            {
                                int[] theNumber = new int[] { a, b, c, d, e };
                                if (IsValid(theNumber))
                                {
                                    theList.Add(new int[] { a, b, c, d, e });
                                }
                            }
                        }
                    }
                }
            }
            return theList.ToArray();
            bool IsValid(int[] numberArray)
        {
            int differentNumbers = (from i in numberArray
                                    group i by i into gr
                                    select gr).Count();
            return differentNumbers == 5;
        }
        }
        [SetUp]
        public void Setup()
        {

        }

        //HandType DetermineHandType(List<ICard> inputHand)
        //  if (IsRoyalStraightFlush(hand))
     //   [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsRoyalStraightFlush(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♣10♣J♣Q♣K♣A",
                "♥10♥J♥Q♥K♥A"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.RoyalStraightFlush, cardsString, positionsPermutation);
        }

        //  if (IsStraightFlush(hand))
    //    [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsStraightFlush(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♣9♣10♣J♣Q♣K",
                "♥A♥2♥3♥4♥5"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.StraightFlush, cardsString, positionsPermutation);
        }
        //   if (IsFourOfAKind(hand))
     //   [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsFourOfAKind(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♦A♥A♣A♠A♣K",
                "♦9♥9♣9♠9♣K"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.FourOfAKind, cardsString, positionsPermutation);
        }
        //   if (IsFullHouse(hand))
     //   [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsFullHouse(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♦A♥A♣A♠K♣K",
                "♦9♥9♣9♠2♣2"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.FullHouse, cardsString, positionsPermutation);
        }
        //    if (IsFlush(hand))
    //    [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsFlush(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♥A♥2♥3♠4♥6",
                "♦10♦J♦Q♦K♦8"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.Flush, cardsString, positionsPermutation);
        }
        //    if (IsStraight(hand)) 
     //   [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsStraight(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♦A♥2♣3♠4♣5",
                "♦10♥J♣Q♠K♣9"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.Straight, cardsString, positionsPermutation);
        }
        //    if (IsThreeOfAKind(hand)) 
        [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsThreeOfAKind(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♦A♥A♣A♠4♣5",
                "♦2♥2♣2♠K♣9"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.ThreeOfAKind, cardsString, positionsPermutation);
        }
        //    if (IsTwoPair(hand)) 
        [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsTwoPair(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♣2♦2♥4♥A♣A",
                "♣K♦2♥6♥K♣6"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.TwoPairs, cardsString, positionsPermutation);
        }
        //    if (IsPair(hand))
             [Test, Combinatorial]
            public void Assert_DetermineHandType_CorrectlyOutputsPair(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
            [Values(
                    "♣2♦3♥4♥A♣A",
                    "♣K♦2♥4♥K♣5"
                )] string cardsString
            )
            {
                AssertCorrectHandType(HandType.Pair, cardsString, positionsPermutation);
            }
        // if (IsHighCard(hand))
        [Test, Combinatorial]
            public void Assert_DetermineHandType_CorrectlyOutputsHighCard(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
            [Values(
                    "♣2♦3♥4♥5♣7",
                    "♣A♦K♥Q♥J♣3"
                )] string cardsString
            )
            {
                AssertCorrectHandType(HandType.HighCard, cardsString, positionsPermutation);
            }
       
       


        


        //List<IPlayer> DetermineWinners(List<IPlayer> players)
        [Test]
        public void Assert_DetermineWinners_DeterminesCorrectWinnersWhenSuperiorHandtype(){
            //TODO write
        }
        [Test]
        public void Assert_DetermineWinners_DeterminesCorrectlyWhenDraw(){
            //TODO write
        }
        [Test]
        public void Assert_DetermineWinners_WhenEqualHandtypeButSuperiorRank(){
            //TODO write one function for each HandType
        }
        [Test]
        public void Assert_DetermineWinners_EveryoneCanWin(){
            //TODO write
        }
        //List<ICard> SortByRankAndSuite(List<ICard> cards)
        [Test, Sequential]
        public void Assert_SortByRankAndSuite_Sorts([Values(
                    "♣4♦3♥5♥2♣7",
                    "♣A♦K♥Q♥J♣3"
                )] string cardsStringInput, [Values(
                    "♥2♦3♣4♥5♣7",
                    "♣3♥J♥Q♦K♣A"
                )] string cardsStringExpected){
                    List<ICard> input = new List<ICard>(ToCards(cardsStringInput));
                    List<ICard> expected = new List<ICard>(ToCards(cardsStringExpected));
                    input = ScoreLogic.SortByRankAndSuite(input);
                    for(int i = 0; i<expected.Count; i++){
                        Assert.True(expected[i].Equals(input[i]));
                    }
                    
        }

        static List<Card> ToCards(string text)
        {
            var cards = new List<Card>();
            int i = 0;
            while (i < text.Length)
            {
                Suite suite;
                switch (text[i])
                {
                    case '♣':
                        suite = Suite.Clubs;
                        break;
                    case '♦':
                        suite = Suite.Diamonds;
                        break;
                    case '♥':
                        suite = Suite.Hearts;
                        break;
                    case '♠':
                        suite = Suite.Spades;
                        break;
                    default: throw new System.NotImplementedException();
                }
                var rankString = text.Substring(i + 1);
                var rankFunc = new Dictionary<string, System.Func<string, Rank>>() {
                {@"^J",  _ => Rank.Jack}, {@"^Q", _ => Rank.Queen}, {@"^K", _ => Rank.King},
                {@"^A", _ => Rank.Ace}, { @"^\d+", str => (Rank)int.Parse(str) }
            };
                try{var func = rankFunc.Where(func => Regex.IsMatch(rankString, func.Key)).First();
                cards.Add(new Card(func.Value(Regex.Match(rankString, func.Key).Value), suite));
                i += Regex.IsMatch(rankString, @"^\d\d") ? 3 : 2;}
                catch{throw new System.Exception("Wrong cardstring syntax");}
            }
            return cards;

        }

        static public void AssertCorrectHandType(HandType expected, string cardsString, int[] permutation)
        {
            List<ICard> cards = new List<ICard>(ToCards(cardsString));
            ICard[] shuffledCards = new ICard[5];
            for (int i = 0; i < cards.Count; i++)
            {
                shuffledCards[permutation[i]] = cards[i];
            }
            HandType actual = ScoreLogic.DetermineHandType(new List<ICard>(shuffledCards));
            Assert.AreEqual(expected, actual);
        }

    }
}