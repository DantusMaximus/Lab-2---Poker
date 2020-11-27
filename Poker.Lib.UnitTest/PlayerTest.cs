using NUnit.Framework;
using System.Collections.Generic;
namespace Poker.Lib.UnitTest
{
    public class PlayerTest
    {
        Player player;
        [SetUp]
        public void Setup()
        {
            player = new Player("Lars");
        }
        [Test]
        public void Assert_Constructor_CreatesPlayerCorrectly()
        {
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
            Assert.AreEqual(givenCards[0], card1);
            Assert.AreEqual(givenCards[1], card2);
        }
        [Test]
        public void Assert_Give_ThrowsOutOfRangeExceptionOnNoCards(){
            var givenCards = new List<ICard>();
            Assert.Throws(     typeof(System.ArgumentOutOfRangeException), delegate{player.Give(givenCards);}    );
        }
        [Test]
        public void Assert_Give_WontOverflowHand(){
            var cards = new List<ICard>();
            cards.Add(new Card(Rank.Three, Suite.Hearts));
            cards.Add(new Card(Rank.Six, Suite.Clubs));
            cards.Add(new Card(Rank.King, Suite.Spades));
            cards.Add(new Card(Rank.Two, Suite.Clubs));
            cards.Add(new Card(Rank.Ten, Suite.Hearts));
            cards.Add(new Card(Rank.Three, Suite.Diamonds));
            Assert.DoesNotThrow( delegate{player.Give(cards);}    );
        }
        [Test]
        public void Assert_RemoveCards_RemovesCorrectly(){
            player.hand.Add(new Card(Rank.Three, Suite.Hearts));
            player.hand.Add(new Card(Rank.Six, Suite.Clubs));
            player.hand.Add(new Card(Rank.King, Suite.Spades));
            player.hand.Add(new Card(Rank.Two, Suite.Clubs));
            player.hand.Add(new Card(Rank.Ten, Suite.Hearts));
            var disc = new ICard[2];
            disc[0] = new Card(Rank.Three, Suite.Hearts);
            disc[1] = new Card(Rank.Six, Suite.Clubs);
            ((IPlayer)player).Discard = disc;
            player.RemoveCards();
            Assert.AreEqual(player.hand.Count, 3);
        }
        [Test]
        public void Assert_JustWon_AddsWins(){
            player.JustWon();
            Assert.AreEqual(1, ((IPlayer)player).Wins);
        }
        [Test]
        public void Assert_ToString_ReturnsString(){
            var str = player.ToString();
            Assert.AreEqual(str, "Lars 0");
        }
    }
}