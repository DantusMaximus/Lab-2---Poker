using System.Collections.Generic;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("Poker.Lib.UnitTest")]
namespace Poker.Lib
{
    class StandardGame : IPokerGame
    {
        private string fileName;

        private List<IPlayer> players;
        private Deck deck;
        private bool onGoing;
        public bool OnGoing { get=>onGoing;}
        public IPlayer[] Players { get => players.ToArray(); }
        public StandardGame(string fileName)
        {
            deck = new Deck();
            this.fileName = fileName;
            Reader reader = new Reader(fileName);
            players = FileManager.LoadGame(reader);
        }

        public StandardGame(string[] playerNames)
        {
            foreach(var playerName in playerNames){
                
                if(playerName == null){  throw new System.NullReferenceException();}
            }

            if (playerNames.Length > 5) { throw new System.Exception("Error: Too many players. At most 5 accepted."); }

            if (playerNames.Length < 2) { throw new System.Exception("Error: Too few players. At least 2 required."); }

            deck = new Deck();
            players = new List<IPlayer>();
            for (int i = 0; i < playerNames.Length; i++)
            {
                players.Add(new Player(playerNames[i]));
            }
        }
        public event OnNewDeal NewDeal;
        public event OnSelectCardsToDiscard SelectCardsToDiscard;
        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        public void Exit()
        {
            onGoing = false;
        }

        public void RunGame()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            onGoing = true;
            while (onGoing)
            {
                fullGame();
            }
        }

        private void fullGame()
        {
            InitialDeal();
            Playerturns();
            DetermineWinner();
            deck.ShuffleInCards();
        }

        private void DetermineWinner()
        {
            ShowAllHands();
            List<IPlayer> winners = ScoreLogic.DetermineWinners(players);
            if (winners.Count == 1)
            {
                Player theWinner = (Player)winners[0];
                theWinner.JustWon();
                Winner(winners.ToArray()[0]);
            }
            else
            {
                Draw(winners.ToArray());
            }
        }

        public void SaveGameAndExit(string fileName)
        {
            var writer = new Writer(fileName);
            FileManager.SaveGame(writer, players);
            Exit();
        }
        private void InitialDeal()
        {
            NewDeal();
            foreach (Player player in players)
            {
                player.hand = new Hand(player, deck.Draw(5));
                player.hand.Cards = ScoreLogic.SortByRankAndSuite(player.hand.Cards);
            }

        }


        private void Playerturns()
        {
            foreach (Player player in players)
            {
                SelectCardsToDiscard(player);
                player.RemoveCards();
                Hand hand = player.hand;
                player.Give(deck.Draw(5 - hand.Count));
                hand.Cards = ScoreLogic.SortByRankAndSuite(hand.Cards);
                hand.HandType = ScoreLogic.DetermineHandType(hand.Cards);
                RecievedReplacementCards(player);
            }
        }


    }
}