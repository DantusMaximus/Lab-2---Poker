using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    /*public class StandardGameTest
    {
        [SetUp]

        [Test]
        public void Assert_Constructor_ThrowsException_OnNullReader(){
            Assert.Throws(typeof(System.NullReferenceException),
            delegate { 
                IReader reader = null;
                new StandardGame(reader);
                 });
        }

        [Test]
        public void Assert_Constructor_ThrowsExceptionOnNullPlayers()
        {
            var playerNames = new string[] { null, null };
            Assert.Throws(typeof(System.NullReferenceException),
            delegate { new StandardGame(playerNames); });
        }
        [Test]
        public void Assert_Constructor_ThrowsExceptionOnTooFewPlayers()
        {
            var playerNames = new string[] { "Magdalena" };
            Assert.Throws(typeof(System.Exception),
            delegate { new StandardGame(playerNames); });
        }
        [Test]
        public void Assert_Constructor_ThrowsExceptionOnTooManyPlayers()
        {
            var playerNames = new string[] {"Magdalena", "Evert", "Sara",
        "Skurt", "Magnus Carlsen", "Capablanca", "Mikhail Tal"};
            Assert.Throws(typeof(System.Exception),
            delegate { new StandardGame(playerNames); });
        }
        [Test]
        public void Assert_Constructor_CreatesNewStandardGame()
        {
            var playerNames = new string[] {"Magdalena", "Evert", "Sara",
        "Skurt"};
            var standardGame = new StandardGame(playerNames);
            var players = standardGame.Players;
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(playerNames[i], players[i].Name);
            }
        }
        [Test]
        public void Assert_Exit_SetsOngoingToFalse()
        {
            var playerNames = new string[] {"Magdalena", "Evert", "Sara",
        "Skurt"};
            var standardGame = new StandardGame(playerNames);
            standardGame.Exit();
            Assert.AreEqual(false, standardGame.OnGoing);
        }
        [Test]
        public void Assert_RunGame_InitialDealDealsCards()
        {

            var playerNames = new string[] { "Magdalena", "Evert" };
            StandardGame standardGame = new StandardGame(playerNames);
            standardGame.NewDeal += Generell;
            int a = 0;
            standardGame.SelectCardsToDiscard += OnSelectCardsToDiscards;
            standardGame.RecievedReplacementCards += OnSelectCardsToDiscards;
            standardGame.RunGame();
            void OnSelectCardsToDiscards(IPlayer player)
            {
                Assert.AreEqual(5, player.Hand.Length);
                a++;
                if (a == 2) { Assert.Pass(); }
            }
            void Generell()
            {
                ;
            }
        }

        [Test]
        public void Assert_RunGame_DetermineWinnerWins()
        {
            var playerNames = new string[] { "Magdalena", "Evert" };
            StandardGame standardGame = new StandardGame(playerNames);

            standardGame.NewDeal += MockNewDeal;
            standardGame.SelectCardsToDiscard += MockSelectCardsToDiscard;
            standardGame.RecievedReplacementCards += MockRecievedReplacementCards;
            standardGame.ShowAllHands += SetHands;
            standardGame.Winner += MockWinner;
            standardGame.RunGame();

            void MockNewDeal() { }
            void MockSelectCardsToDiscard(IPlayer player) { }
            void MockRecievedReplacementCards(IPlayer player) { }
            void SetHands()
            {
                ChangeHand(standardGame.Players[0], "♣A♣K♣Q♣J♣10");
                ChangeHand(standardGame.Players[1], "♠8♣8♠2♠A♦3");
            }
            void MockWinner(IPlayer winner)
            {
                Assert.AreSame(standardGame.Players[0], winner);
                Assert.Pass();
            }

        }

        [Test]
        public void Assert_RunGame_FinishesRunningWhenExitIsCalledAfterMatch()
        {
            var playerNames = new string[] { "Magdalena", "Evert" };
            StandardGame standardGame = new StandardGame(playerNames);
            int newDealCalls = 0;
            standardGame.NewDeal += MockNewDeal;
            standardGame.SelectCardsToDiscard += MockWithIPlayerParam;
            standardGame.RecievedReplacementCards += MockWithIPlayerParam;
            standardGame.ShowAllHands += SetHands;
            standardGame.Draw += CallExitFunction;
            standardGame.RunGame();

            Assert.Pass();

            void MockNewDeal()
            {
                if (++newDealCalls == 2) { Assert.Fail("Did not exit game. Started a new round instead."); }
            }

            void CallExitFunction(IPlayer[] winners)
            {
                standardGame.Exit();
            }
            void SetHands()
            {
                ChangeHand(standardGame.Players[0], "♣A♣K♣Q♣J♣10");
                ChangeHand(standardGame.Players[1], "♣A♣K♣Q♣J♣10");
            }
            void MockWithIPlayerParam(IPlayer player) { }
        }

        //testa att köra "en till" TODO
        [Test]
        public void Assert_RunGame_CanRematch()
        {
            var playerNames = new string[] { "Magdalena", "Evert" };
            StandardGame standardGame = new StandardGame(playerNames);
            int newDealCalls = 0;
            standardGame.NewDeal += MockNewDeal;
            standardGame.SelectCardsToDiscard += MockWithIPlayerParam;
            standardGame.RecievedReplacementCards += MockWithIPlayerParam;
            standardGame.ShowAllHands += SetHands;
            standardGame.Winner += MockWithIPlayerParam;

            standardGame.RunGame();
            void SetHands()
            {
                ChangeHand(standardGame.Players[0], "♣A♣K♣Q♣J♣10");
                ChangeHand(standardGame.Players[1], "♠8♣8♠2♠A♦3");
            }
            void MockNewDeal()
            {
                if (++newDealCalls == 2) { Assert.Pass(); }
            }
            void MockWithIPlayerParam(IPlayer player) { }

        }
        //DetermineWinner on Draw TODO
        [Test]
        public void Assert_RunGame_DeterminesDrawBetweenMultipleWinners()
        {

            var playerNames = new string[] { "Magdalena", "Evert", "Saul" };
            StandardGame standardGame = new StandardGame(playerNames);

            standardGame.NewDeal += MockNewDeal;
            standardGame.SelectCardsToDiscard += MockSelectCardsToDiscard;
            standardGame.RecievedReplacementCards += MockRecievedReplacementCards;
            standardGame.ShowAllHands += SetHands;
            standardGame.Winner += Fail;
            standardGame.Draw += MockDraw;
            standardGame.RunGame();


            void MockNewDeal() { }
            void MockSelectCardsToDiscard(IPlayer player) { }
            void MockRecievedReplacementCards(IPlayer player) { }
            void SetHands()
            {
                ChangeHand(standardGame.Players[0], "♣A♣K♣Q♦J♣10"); //winner
                ChangeHand(standardGame.Players[1], "♠8♣8♠2♠A♦3");  //loser
                ChangeHand(standardGame.Players[2], "♦A♦K♦Q♦J♣10"); //winner           
            }

            void MockDraw(IPlayer[] winners)
            {
                Assert.AreEqual(2, winners.Length);
                Assert.Contains(standardGame.Players[0], winners);
                Assert.Contains(standardGame.Players[2], winners);
                Assert.Pass();
            }
            void Fail(IPlayer winner)
            {
                Assert.Fail("Only '" + winner.Name + "' won. Should have been Draw.");
            }
        }


        void ChangeHand(IPlayer iPlayer, string newHand)
        {
            Player player = ((Player)iPlayer);
            Hand hand = player.hand;
            List<ICard> firstHand = new List<ICard>(hand.Cards);
            foreach (ICard card in firstHand)
            {
                hand.Remove(card);
            }
            foreach (ICard card in ScoreLogicTest.ToCards(newHand))
            {
                hand.Add(card);
            }

        }
    }*/
}