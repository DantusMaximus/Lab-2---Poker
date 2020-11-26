using NUnit.Framework;
using System.Collections.Generic;
namespace Poker.Lib.UnitTest
{
    public class PlayerTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Assert_Constructor_CreatesPlayerCorrectly()
        {
            var player = new Player("Lars", 0);
            Assert.AreEqual(((IPlayer)player).Wins, 0);
            Assert.AreEqual(((IPlayer)player).Name, "Lars");
            Assert.AreEqual(player.hand.Player, player);
            ICard[] empty = new ICard[0];
            Assert.AreEqual(((IPlayer)player).Discard, empty);
        }
        [Test]
        public void Assert_Constructor_ThrowsNullReferenceExceptionOnNull()
        {
            Assert.Throws(     typeof(System.NullReferenceException), delegate{new Player(null, 0);}    );
        }
        [Test]
        public void Assert_Give_GivesCard(){
            var card1 = new Card(Rank.Three, Suite.Diamonds);
            var card2 = new Card(Rank.Two, Suite.Clubs);
            var givenCards = new List<ICard>();
            givenCards.Add(card1);
            givenCards.Add(card2);
        }
        [Test]
        public void Assert_Give_ThrowsNullExceptionOnInvalidCards(){
            var givenCards =
            Assert.True()
            Assert.Throws(     typeof(System.NullReferenceException), delegate{new Player(null, 0);}    );
        }
    }
}