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

        public IPlayer[] Players { get; set;}

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
            //Deal cards to every player, untill everyone has 5 cards, with backside up
            NewDeal();
            foreach(Player player in Players){
                player.Give(deck.Draw(5));
            }
            foreach(Player player in Players){
                SelectCardsToDiscard(player);
                player.RemoveCards();
                player.Give(deck.Draw(5-player.hand.Count));
                RecievedReplacementCards(player);
            }
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