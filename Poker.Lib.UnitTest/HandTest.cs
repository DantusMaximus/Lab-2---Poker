using NUnit.Framework;

namespace Poker.Lib.UnitTest
{
    public class HandTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AssertAddAddsCardsWhenLenghtIsLessThanFive(){
            Hand hand = new Player("Ada Lovelace").hand;
            Card testCard1 = new Card(Rank.Two,Suite.Clubs);
            Card testCard2 = new Card(Rank.Six,Suite.Clubs);

            hand.Add(testCard1);
            hand.Add(new Card(Rank.Three,Suite.Clubs));
            hand.Add(new Card(Rank.Four,Suite.Clubs));
            hand.Add(new Card(Rank.Five,Suite.Clubs));
            hand.Add(testCard2);

            Assert.AreEqual(testCard1,hand.Cards[0]);
            Assert.AreEqual(testCard2,hand.Cards[4]);
        }
        [Test]
        public void AssertAddThrowsErrorWhenHandSizeIsFive(){            
            Hand hand = new Player("Ada Lovelace").hand;
            Assert.Throws(typeof(System.Exception), delegate{
                for(int i = 0; i < 6; i++){
                    hand.Add(new Card((Rank)i,Suite.Clubs));
                }       
            });
        }
        [Test]
        public void AssertContainsReturnsTrueWhenTrue(){           
            Hand hand = new Player("Ada Lovelace").hand;
            Card testCard1 = new Card(Rank.Two,Suite.Clubs);
            Card testCard2 = new Card(Rank.Two,Suite.Clubs);
            hand.Add(testCard1);
            Assert.True(hand.Contains(testCard2));
        }
        [Test]
        public void AssertRemoveRemoves(){
            Hand hand = new Player("Ada Lovelace").hand;
            Card testCard1 = new Card(Rank.Two,Suite.Clubs);
            Card testCard2 = new Card(Rank.Two,Suite.Clubs);
            hand.Add(testCard1);
            hand.Remove(testCard2);
            Assert.False(hand.Contains(testCard1));
        }
        [Test]
        public void AssertIsFullReturnsTrueFiveCardsInHand(){            
            Hand hand = new Player("Ada Lovelace").hand;
            for(int i = 0; i < 5; i++){                
                hand.Add(new Card((Rank)i,Suite.Clubs));
            }
            Assert.True(hand.IsFull());
        }
        [Test]
        public void AssertIsFullReturnsFalseOnZeroCards(){
            Hand hand = new Player("Ada Lovelace").hand;
            Assert.False(hand.IsFull());
        }
        [Test]
        public void AssertIsFullReturnsFalseOnFourCards(){
            Hand hand = new Player("Ada Lovelace").hand;
            for(int i = 0; i < 4; i++){                
                hand.Add(new Card((Rank)i,Suite.Clubs));
            }
            Assert.False(hand.IsFull());
        }
    }
}