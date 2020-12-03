using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class StandardGameTest
    {
        [SetUp]

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
        public void Assert_Constructor_CreatesNewStandardGame(){
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
        public void Assert_Exit_SetsOngoingToFalse(){
            var playerNames = new string[] {"Magdalena", "Evert", "Sara",
        "Skurt"};
            var standardGame = new StandardGame(playerNames);
            standardGame.Exit();
            Assert.AreEqual(false, standardGame.OnGoing);
        }
        [Test]
        public void Assert_RunGame_InitialDealDealsCards(){

            var playerNames = new string[] {"Magdalena", "Evert"};
            StandardGame standardGame = new StandardGame(playerNames);
            standardGame.NewDeal += Generell;
            int a = 0;
            standardGame.SelectCardsToDiscard += OnSelectCardsToDiscards;
            standardGame.RecievedReplacementCards += OnSelectCardsToDiscards;
            /*
            game.NewDeal += OnNewDeal; DONE
            game.SelectCardsToDiscard += OnSelectCardsToDiscard; DONE
            game.RecievedReplacementCards += OnRecievedReplacementCards; DONE
            game.ShowAllHands += OnShowAllHands;
            game.Winner += OnWinner;
            game.Draw += OnDraw;
            */
            standardGame.RunGame();
            void OnSelectCardsToDiscards(IPlayer player){
                Assert.AreEqual(5, player.Hand.Length);
                a++;
                if(a == 2){  Assert.Pass();  }
            }
            void Generell(){
                ;
            }
        }

        [Test]
        public void Assert_RunGame_DetermineWinnerWins(){
            var playerNames = new string[] {"Magdalena", "Evert"};
            StandardGame standardGame = new StandardGame(playerNames);

            standardGame.NewDeal += MockNewDeal;
            standardGame.SelectCardsToDiscard += MockSelectCardsToDiscard;
            standardGame.RecievedReplacementCards += MockRecievedReplacementCards;
            standardGame.ShowAllHands += SetHands;
            standardGame.Winner += MockWinner;
            standardGame.RunGame();
            
            void MockNewDeal(){}
            void MockSelectCardsToDiscard(IPlayer player){}
            void MockRecievedReplacementCards(IPlayer player){}
            void SetHands(){
               ChangeHand(0,"♣A♣K♣Q♣J♣10");
               ChangeHand(1,"♠8♣8♠2♠A♦3");
            }
            void MockWinner(IPlayer winner){
                Assert.AreSame(standardGame.Players[0], winner);
                Assert.Pass();
            }
            
            void ChangeHand(int playerIndex, string newHand){
                 Player player = ((Player)standardGame.Players[playerIndex]);
                Hand hand = player.hand;                
                List<ICard> firstHand = new List<ICard>(hand.Cards);
                foreach(ICard card in firstHand){
                    hand.Remove(card);
                }             
                foreach(ICard card in ScoreLogicTest.ToCards(newHand)){
                    hand.Add(card);
                }
                
            }
            

        }
        //deck.ShuffleInCards TODO
        //DetermineWinner on Draw TODO
    }
}