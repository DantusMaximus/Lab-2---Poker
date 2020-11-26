using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class DeckTest{
        //skum ändring
        Deck deck;

        [SetUp]
        public void Setup()
        {
            deck = new Deck();
        }
       //Constructor
        [Test]
        public void Assert_Constructor_FillsDeckWithFiftyTwoCards(){
            deck = new Deck();
            Assert.DoesNotThrow(delegate{
                deck.Draw(52);
            });
            
        }
        //Randomize()

        //ShuffleInCards()
        [Test]
        public void Assert_ShuffleInCards_ShufflesInCards(){
            deck.Draw(52);
            deck.ShuffleInCards();
            Assert.DoesNotThrow(delegate{
                deck.Draw(1);
            });
        }
        //Draw
        [Test]
        public void Assert_Draw_RemovesDrawnCards(){
            List<ICard> removedCards = deck.Draw(52);
            Assert.Throws(typeof(System.ArgumentOutOfRangeException), delegate{
                deck.Draw(1);
            });                     
            var differentCards = from card in removedCards
                            group card by new{card.Rank, card.Suite} into gr                            
                            select gr;
            Assert.AreEqual(52,differentCards.Count());
        }
    }
}