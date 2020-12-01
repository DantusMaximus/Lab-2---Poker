using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class ScoreLogicTest
    {
        static public int[][] allValidPositionCombos = allPositionCombinations();
        [SetUp]
        public void Setup()
        {

        }

        //HandType DetermineHandType(List<ICard> inputHand)
        //  if (IsRoyalStraightFlush(hand)) 

        //  if (IsStraightFlush(hand))

        //   if (IsFourOfAKind(hand))

        //   if (IsFullHouse(hand))

        //    if (IsFlush(hand))

        //    if (IsStraight(hand)) 

        //    if (IsThreeOfAKind(hand)) 

        //    if (IsTwoPair(hand)) 

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
        }
        static private bool IsValid(int[] numberArray)
        {
            int differentNumbers = (from i in numberArray
                                    group i by i into gr
                                    select gr).Count();
            return differentNumbers == 5;
        }

        [Test, Combinatorial,]
        // [TestCaseSource(nameof(allValidPositionCombos))]
        public void Assert_DetermineHandType_CorrectlyOutputsTwoPair(/*int[] positionsString,*/
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♣2♦2♥4♥A♣A",
                "♣K♦2♥6♥K♣6"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.TwoPairs, cardsString, positionsPermutation);
        }


     
            static int[][] PositionCombos = ScoreLogicTest.allValidPositionCombos;
             [Test, Combinatorial]
            public void Assert_DetermineHandType_CorrectlyOutputsPair(
            [ValueSource("PositionCombos")] int[] positionsPermutation,
            [Values(
                    "♣2♦3♥4♥A♣A",
                    "♣K♦2♥4♥K♣5"
                )] string cardsString
            )
            {
                AssertCorrectHandType(HandType.Pair, cardsString, positionsPermutation);
            }
     
       
       


        //    if (IsPair(hand))

        // [Test, Sequential]
        public void SequentialTestExample(
            [Values(1, 2, 3)] int x,
            [Values("C", "D", "E")] string s
            )
        {
            Assert.True(x < 4 && s[0] >= 'C');
        }
        /* IsCalled 6 Times, as follows:
             SequentialTestExample(1, "A")
             SequentialTestExample(2, "B")
             SequentialTestExample(3, "E")
        */

        //List<IPlayer> DetermineWinners(List<IPlayer> players)

        //List<ICard> SortByRankAndSuite(List<ICard> cards)

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
                    case '♥':
                        suite = Suite.Hearts;
                        break;
                    case '♦':
                        suite = Suite.Diamonds;
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
                var func = rankFunc.Where(func => Regex.IsMatch(rankString, func.Key)).First();
                cards.Add(new Card(func.Value(Regex.Match(rankString, func.Key).Value), suite));
                i += Regex.IsMatch(rankString, @"^\d\d") ? 3 : 2;
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