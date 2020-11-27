using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class DeckTest{
      
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
        [Test]
        public void Probably_Randomize_isRandom(){
            List<ICard> pull1 = deck.Draw(52);
            List<ICard> pull2 = new Deck().Draw(52);
            List<ICard> pull3 = new Deck().Draw(52);
            bool identicalOrder = true;
            for(int i = 0; i < pull1.Count; i++){
                if(pull1[i] != pull2[i] || pull1[i] != pull3[i]){
                    identicalOrder = false;
                    break;
                }
            }
            Assert.False(identicalOrder);
        }
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