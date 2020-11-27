using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class ScoreLogicTest
    {
        int[] apaLista;
        //HandType DetermineHandType(List<ICard> inputHand)
            //  if (IsRoyalStraightFlush(hand)) 

            //  if (IsStraightFlush(hand))
         
            //   if (IsFourOfAKind(hand))
         
            //   if (IsFullHouse(hand))
        
            //    if (IsFlush(hand))
        
            //    if (IsStraight(hand)) 
        
            //    if (IsThreeOfAKind(hand)) 
        
            //    if (IsTwoPair(hand)) 
       [SetUp]
       public void SetUp(){
           apaLista = new int[] {123, 123};
       }
   

        [Test, Combinatorial]
        public void Assert_DetermineHandType_CorrectlyOutputsTwoPair(
             [Values("♣2", "♦2", "♥4", "♥A", "♣A")] string string1,
             [Values("♣2", "♦2", "♥4", "♥A", "♣A")] string string2,
             [Values("♣2", "♦2", "♥4", "♥A", "♣A")] string string3,
             [Values("♣2", "♦2", "♥4", "♥A", "♣A")] string string4,
             [Values("♣2", "♦2", "♥4", "♥A", "♣A")] string string5
        )
        {
            bool cheat = false;
            string[] strings = {string1, string2, string3, string4, string5};
            for(int i =0;i<5;i++){
                for(int j = 0; j<5;j++){
                    if(strings[i] == strings[j] && i!= j){
                        cheat = true;
                    }
                }
            }
            if(cheat == true){;}
            else{
                string cardStrings = "";
                foreach(string str in strings){
                    cardStrings += str;
                }
                List<ICard> cards = new List<ICard>(ToCards(cardStrings));
                HandType actual = ScoreLogic.DetermineHandType(cards);
                Assert.AreEqual(HandType.TwoPairs, actual);
        }
        }
            //    if (IsPair(hand))
        [Test, Sequential]
        public void Assert_DetermineHandType_CorrectlyOutputsPair(
            [Values(
                "♣2♦2♥3♥4♥5", "♠3♥7♠7♠8♠9", "♣9♣10♦J♥J♣Q", "♦J♦Q♦K♣A♠A" 
            )] string cardsString
        )
        {
                List<ICard> cards = new List<ICard>(ToCards(cardsString));
                HandType actual = ScoreLogic.DetermineHandType(cards);
                Assert.AreEqual(HandType.Pair, actual);

        }
       // [Test, Sequential]
        public void SequentialTestExample(
            [Values(1,2,3)] int x,
            [Values("C", "D", "E")] string s
            )
        {
            Assert.True(x <4 && s[0] >= 'C');
        }
           /* IsCalled 6 Times, as follows:
                SequentialTestExample(1, "A")
                SequentialTestExample(2, "B")
                SequentialTestExample(3, "E")
           */

        //List<IPlayer> DetermineWinners(List<IPlayer> players)

        //List<ICard> SortByRankAndSuite(List<ICard> cards)

        static List<Card> ToCards(string text){
            var cards = new List<Card>();
            int i = 0;            
            while(i < text.Length) {
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
            cards.Add( new Card( func.Value(Regex.Match(rankString, func.Key).Value),suite));
            i += Regex.IsMatch(rankString, @"^\d\d") ? 3 : 2;
            }
            return cards;
             
        }

    }
}