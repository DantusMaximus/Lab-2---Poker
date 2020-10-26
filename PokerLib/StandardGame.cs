using System.Collections.Generic;

namespace Poker.Lib
{
    class StandardGame : IPokerGame
    {
        private string fileName;
        private string[] playerNames;
        private List<IPlayer> players;
        private Deck deck;        
        public IPlayer[] Players { get => players.ToArray();}
        public StandardGame(string fileName)//TODO implement a way to load saved files
        {
            this.fileName = fileName;
        }

        public StandardGame(string[] playerNames)
        {
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
            throw new System.NotImplementedException();
        }

        public void RunGame()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            deck = new Deck();
            InitialDeal();
            Playerturns();
            DetermineWinner();
            //Determine winner
            //Redo
            throw new System.NotImplementedException();
        }

        private void DetermineWinner()
        {   
            List<IPlayer> winners = ScoreLogic.DetermineWinners(players);
            ShowAllHands();
            if(winners.Count == 1){
                Winner(winners.ToArray()[0]);
            }
            else{
                Draw(winners.ToArray());
            }
            throw new System.NotImplementedException();
        }

        public void SaveGameAndExit(string fileName)
        {
            throw new System.NotImplementedException();
        }
        private void InitialDeal(){
            NewDeal();
            foreach(Player player in players){
                player.Give(deck.Draw(5));
                player.hand.Cards = ScoreLogic.SortByRankAndSuite(player.hand.Cards);
            }
            
        }
        
        
        private void Playerturns(){
            foreach(Player player in players){
                SelectCardsToDiscard(player);
                player.RemoveCards();
                Hand hand = player.hand;
                player.Give(deck.Draw(5-hand.Count));
                hand.Cards = ScoreLogic.SortByRankAndSuite(hand.Cards);
                hand.HandType = ScoreLogic.DetermineHandType(hand.Cards);
                RecievedReplacementCards(player);
            }
        }
        
        
    }
}