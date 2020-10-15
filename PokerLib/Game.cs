using Poker;
using Poker.Lib;
class Game : IPlayer, IPokerGame{
string IPlayer.Name { get; }

        ICard[] IPlayer.Hand { get; }

        HandType IPlayer.HandType { get; }

        int IPlayer.Wins { get; }

        ICard[] IPlayer.Discard { get; set; }
         IPlayer[] Players { get; }

        void IPokerGame.RunGame();

        void IPokerGame.Exit();

        void IPokerGame.SaveGameAndExit(string fileName);
        public event OnDraw Draw{
            add{
                ;
            } remove{
                ;
            }
            }
        event OnSelectCardsToDiscard SelectCardsToDiscard;

        event OnRecievedReplacementCards RecievedReplacementCards;

        event OnShowAllHands ShowAllHands;

        event OnWinner Winner;

        event OnDraw Draw;
    }
}