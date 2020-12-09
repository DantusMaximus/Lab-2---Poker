using NUnit.Framework;
using System.Collections.Generic;
namespace Poker.Lib.UnitTest
{
    public class HandTest
    {
        Hand hand;
        [SetUp]
        public void Setup()
        {
            hand = new Player("Ada Lovelace").hand;
        }


        [Test]
        public void Assert_Add_AddsCardsWhenLenghtIsLessThanFive(){
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
        public void Assert_Add_ThrowsErrorWhenHandSizeIsFive(){            
            Assert.Throws(typeof(System.Exception), delegate{
                for(int i = 0; i < 6; i++){
                    hand.Add(new Card((Rank)i,Suite.Clubs));
                }       
            });
           
        }
        [Test]
        public void Assert_Add_ThrowsErrorWhenCardAlreadyInHand(){  
            hand.Add(new Card(Rank.Ace,Suite.Clubs));

            Assert.Throws(typeof(System.Exception), delegate{                
                    hand.Add(new Card(Rank.Ace,Suite.Clubs));                       
                }
            );
           
        }
        [Test]
        public void Assert_Contains_ReturnsTrueWhenTrue(){           
            Card testCard1 = new Card(Rank.Two,Suite.Clubs);
            Card testCard2 = new Card(Rank.Two,Suite.Clubs);
            hand.Add(testCard1);
            Assert.True(hand.Contains(testCard2));
        }
        [Test]
        public void Assert_Remove_Removes(){
            Card testCard1 = new Card(Rank.Two,Suite.Clubs);
            Card testCard2 = new Card(Rank.Two,Suite.Clubs);
            hand.Add(testCard1);
            hand.Remove(testCard2);
            Assert.False(hand.Contains(testCard1));
        }
        [Test]
        public void Assert_IsFull_ReturnsTrueFiveCardsInHand(){            
            for(int i = 0; i < 5; i++){                
                hand.Add(new Card((Rank)i,Suite.Clubs));
            }
            Assert.True(hand.IsFull());
        }
        [Test]
        public void Assert_IsFull_ReturnsFalseOnZeroCards(){
            Assert.False(hand.IsFull());
        }
        [Test]
        public void Assert_IsFull_ReturnsFalseOnFourCards(){
            for(int i = 0; i < 4; i++){                
                hand.Add(new Card((Rank)i,Suite.Clubs));
            }
            Assert.False(hand.IsFull());
        }
        [Test]
        public void Assert_Constructor_ThrowsNullExceptionOnNullPlayer(){
            var nullException = typeof(System.NullReferenceException);
            
            Assert.Throws(nullException, delegate{hand = new Hand(null);});
            Assert.Throws(nullException, delegate{
                hand = new Hand(    null, new List<ICard>()  );
                });
        }
        [Test]
        public void Assert_Constructor_ThrowsNullExceptionOnNullCards(){
            Assert.Throws(typeof(System.NullReferenceException), delegate{
                hand = new Hand(    new Player("Charles"), null );
                });
        }
        [Test]
         public void Assert_Constructor_SetsPlayerCorrectly(){{
             Player player1 = new Player("Charles Darwin");
             hand = new Hand(player1);
            Assert.AreEqual(player1, hand.Player);
         }
            
        }
    }
}