using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class ScoreLogicTest
    {
        static public int[][] allValidPositionCombos = allPositionCombinations();

        static public List<HandType> AllLowerHandTypesThan(HandType handType){
            List<HandType> allLower= new List<HandType>();
            for(int i = 0; i < (int)handType; i++ ){
                allLower.Add((HandType)i);
            }
            return allLower;
        }

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
        class MockPlayer : IPlayer
        {
            private HandType handType;
            public string Name => throw new System.NotImplementedException();

            public ICard[] Hand => throw new System.NotImplementedException();

            public HandType HandType => handType;

            public MockPlayer(HandType handType){
                this.handType = handType;
            }

            public int Wins => throw new System.NotImplementedException();

            public ICard[] Discard { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        }
        [SetUp]
        public void Setup()
        {

        }

        //HandType DetermineHandType(List<ICard> inputHand)
        //  if (IsRoyalStraightFlush(hand))
        [Test, Combinatorial]
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
        [Test, Combinatorial]
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
        [Test, Combinatorial]
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
        [Test, Combinatorial]
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
        [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsFlush(
            [ValueSource("allValidPositionCombos")] int[] positionsPermutation,
           [Values(
                "♥A♥2♥3♥4♥6",
                "♦10♦J♦Q♦K♦8"
            )] string cardsString
        )
        {
            AssertCorrectHandType(HandType.Flush, cardsString, positionsPermutation);
        }
        //    if (IsStraight(hand)) 
        [Test, Combinatorial]
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
      
            //if (IsRoyalStraightFlush(hand)) 
           // if (IsStraightFlush(hand)) 
           // if (IsFourOfAKind(hand)) 
           // if (IsFullHouse(hand)) 
           // if (IsFlush(hand))
           // if (IsStraight(hand)) 
           // if (IsThreeOfAKind(hand))
           // if (IsTwoPair(hand)) 
           // if (IsPair(hand))

        public static List<HandType> allHandTypes(){
            List<HandType> allHandTypes = new List<HandType>();
            foreach(HandType handType in System.Enum.GetValues(typeof(HandType))){
                allHandTypes.Add(handType);
            }
            return allHandTypes;
        }

        public static List<(HandType,HandType)> firstHigherThanSecondHandTypeCombos(){
            var allCombos = new List<(HandType,HandType)>();            

            foreach(HandType first in System.Enum.GetValues(typeof(HandType))){
                foreach(HandType second in System.Enum.GetValues(typeof(HandType))){
                    if(first > second){
                        allCombos.Add((first, second));
                    }                   
                }
            }
            return allCombos;
        }

        [Test, Combinatorial]
        public void Assert_DetermineWinners_DeterminesSuperiorHandtypeWinner(
            [ValueSource("firstHigherThanSecondHandTypeCombos")] (HandType,HandType) typePair
        ){
            HandType expected = typePair.Item1;
            HandType matchAgainst = typePair.Item2;
        
            AssertDetermineFirstAsWinner(expected,matchAgainst);         
        }

        private void AssertDetermineFirstAsWinner(HandType winnerHandType, HandType loserHandType){
            MockPlayer winner = new MockPlayer(winnerHandType);
            MockPlayer loser = new MockPlayer(loserHandType);           
            var winners = ScoreLogic.DetermineWinners(new List<IPlayer>(){winner,loser});
            Assert.AreEqual(1,winners.Count);
            Assert.AreEqual(winnerHandType,winners[0].HandType);
        }
        private void AssertDetermineFirstAsWinner(string winnerHand, string loserHand){
            Player winner = new Player(winnerHand);
            Player loser = new Player(loserHand);
            winner.Give(ToCards(winnerHand));
            loser.Give(ToCards(loserHand));
           
            var winners = ScoreLogic.DetermineWinners(new List<IPlayer>(){winner,loser});
            Assert.AreEqual(1,winners.Count);
            Assert.AreEqual(winnerHand,winners[0].Name);
        }



        //if (IsRoyalStraightFlush(hand)) DONE
           // if (IsStraightFlush(hand)) DONE
           // if (IsFourOfAKind(hand)) DONE
           // if (IsFullHouse(hand)) DONE
           // if (IsFlush(hand)) DONE
           // if (IsStraight(hand)) DONE
           // if (IsThreeOfAKind(hand))
           // if (IsTwoPair(hand)) 
           // if (IsPair(hand))
        //TODO:More testcases(longer inparam values[] lists)



        public static List<(string,string)> testCasesForDraws(){
            return new List<(string,string)>(){
                ("♣A♣K♣Q♣J♣10","♦A♦K♦Q♦J♦10"), //RoyalStraightFlush
                ("♣9♣K♣Q♣J♣10","♦9♦K♦Q♦J♦10"), //StraightFlush
                ("♣K♦K♥K♠K♣10","♣K♦K♥K♠K♦10"), //FourOfakind
                ("♣K♦K♥K♠10♣10","♣K♦K♥K♣10♦10") ,//fullhouse
                ("♥2♥3♥4♥5♥7","♦2♦3♦4♦5♦7"), //flush
                ("♣A♣K♣Q♦J♣10","♦A♦K♦Q♦J♣10"), //straight
                ("♦2♣2♠2♠3♠4","♦2♣2♠2♠3♣4"), //ThreeOfAkind
                ("♠8♣8♠A♣A♠4","♣8♠8♣A♠A♠4"), //TwoPair
                ("♦8♣8♠2♠A♠3","♠8♣8♠2♠A♦3"), //Pair
                ("♦2♣3♣4♥5♥8","♦2♣3♣4♣5♥8") //highCard
                }; 
        }
        [Test, Sequential]
        public void Assert_DetermineWinners_DeterminesCorrectlyWhenDraw(
             [ValueSource("testCasesForDraws")] (string,string) hands            
        ){
            Player player1 = new Player("Charles Darwin");
            player1.Give(ToCards(hands.Item1));
            Player player2 = new Player("George Carlin");
            player2.Give(ToCards(hands.Item2));
            Player player3 = new Player("the looser");
            player3.Give(ToCards("♦2♣3♣4♣5♥7"));

            List<IPlayer> winners = ScoreLogic.DetermineWinners(new List<IPlayer>(){player1,player2,player3});
            
            
            Assert.Contains(player1, winners);
            Assert.Contains(player2, winners); 
            Assert.AreEqual(2, winners.Count);           
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
                    List<ICard> input = ToCards(cardsStringInput);
                    List<ICard> expected = ToCards(cardsStringExpected);
                    input = ScoreLogic.SortByRankAndSuite(input);
                    for(int i = 0; i<expected.Count; i++){
                        Assert.True(expected[i].Equals(input[i]));
                    }
                    
        }

        static List<ICard> ToCards(string text)
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
            return new List<ICard>(cards);

        }

        static public void AssertCorrectHandType(HandType expected, string cardsString, int[] permutation)
        {
            List<ICard> cards = ToCards(cardsString);
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