namespace Poker.Lib{
class StandardGame : IPokerGame
{
    IPlayer[] IPokerGame.Players { get; }

        void IPokerGame.RunGame(){
            System.Console.WriteLine("default implementation");
            IPokerGame.NewDeal newDeal += System.Console.WriteLine("tjena");
        }

        void IPokerGame.Exit(){
        }

        void IPokerGame.SaveGameAndExit(string fileName){

        }

        void ShowAllHands(){
            IPokerGame.ShapeChanged?.Invoke(this);
        }
        event OnNewDeal IPokerGame.NewDeal;

        event OnSelectCardsToDiscard IPokerGame.SelectCardsToDiscard;

        event OnRecievedReplacementCards IPokerGame.RecievedReplacementCards;

        event OnShowAllHands IPokerGame.ShowAllHands;

        event OnWinner IPokerGame.Winner;

        event OnDraw IPokerGame.Draw;

        void OnNewDeal(){
            
        }
        OnSelectCardsToDiscard(IPlayer player){

        }
        void OnRecievedReplacementCards(IPlayer player){

        }

        

    

        void OnWinner(IPlayer winner){

        }

        void OnDraw(IPlayer[] tiedPlayers){
            
        }



}
}