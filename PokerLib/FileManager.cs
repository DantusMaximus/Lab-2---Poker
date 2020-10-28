using System.Collections.Generic;
using System.FileStream
namespace Poker{
    class FileManager{
        public bool SaveGame(string fileName, List<IPlayer> players){
            using(var fileName = new FileStream.Open(fileName, FileMode.OpenOr)){
                
            }
            throw new System.NotImplementedException();
        }
        public bool LoadGame(string fileName){
            
            throw new System.NotImplementedException();
        }

        private string ConvertToString(List<IPlayer> players){
            string playersTXT = "";
            foreach(player in players){
                playersTXT += ConvertToString(player);
            }
            return playersTXT;
        }
        private string ConvertToString(IPlayer player){
            string playerTXT;
            playerTXT +=player.Name;
            playerTXT += " ";
            playerTXT += player.Wins;
            playerTXT += "\n";
            return playerTXT
        }

        
        private List<IPlayer> ConvertToPlayers(string playersTXT){
            List<IPlayer> players = new List<IPlayer>();
            int playerAmount = 0; //kolla antal rader i TXT (aka antal spelare)
            for(int i = 0; i < playerAmount;i++ ){
                //Parsestuff
                Player parsedPlayer = ConvertToPlayer(/*parsedstuff*/);
            }
        }
        private IPlayer ConvertToPlayer(string playerTXT){
            throw new NotImplementedException();
        }
    }
}