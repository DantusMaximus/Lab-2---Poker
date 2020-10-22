using System;
namespace Poker.Lib
{
    class StandardGame : IPokerGame
    {
        private string fileName;
        private string[] playerNames;

        public StandardGame(string fileName)//TODO implement a way to load saved files
        {
            this.fileName = fileName;
        }

        public StandardGame(string[] playerNames)
        {
            Players = new IPlayer[playerNames.Length];
            for (int i = 0; i < playerNames.Length; i++)
            {
                Players[i] = new Player(playerNames[i]);
            }
        }

        public IPlayer[] Players { get; }

        public event OnNewDeal NewDeal;
        public event OnSelectCardsToDiscard SelectCardsToDiscard;
        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void RunGame()
        {
            Deck deck = new Deck();
            //Deal cards to every player, 1 to each in order untill everyone has 5 cards, with backside up
            //Sort hands
            //Players choose discard
            //Players get cards from deck
            //Determine winner
            //Redo
            throw new NotImplementedException();
        }

        public void SaveGameAndExit(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}