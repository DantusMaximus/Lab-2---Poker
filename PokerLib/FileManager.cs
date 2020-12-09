using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class FileManager
    {
        //not relevant in current iteration
        private const string path = "";
        //not relevant in current iteration
        static public bool SaveGame(IWriter writer, List<IPlayer> players)
        {
            CreateSaveDirIfNonExistent();
            string saveFile = ConvertToString(players);
            writer.Write(saveFile);
            return true;
        }
        static private void CreateSaveDirIfNonExistent()
        {
            if (path == "") { return; }
            //not relevant in current iteration
            /*if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }*/
            //not relevant in current iteration
        }
        static public List<IPlayer> LoadGame(IReader reader)
        {
            string[] playersStrings = FileToPlayerStrings(reader);
            List<string> approvedPlayers = new List<string>();           
            Regex savedFileFormat = new Regex("^\\w+ \\d+$");
            foreach (string playerString in playersStrings)
            {               
                if (playerString == "")
                {
                    continue;
                }
                if (!savedFileFormat.IsMatch(playerString))
                {
                    throw new System.Exception("Felaktigt filformat on line with " + playerString );
                }
                approvedPlayers.Add(playerString);
            }
            return ConvertToPlayers(approvedPlayers);

        }

        static private string ConvertToString(List<IPlayer> players)
        { //<Name><Space><Ammount of wins> savefile format
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var player in players)
            {
                stringBuilder.Append(player.ToString() + "\n");
            }
            string playersTXT = stringBuilder.ToString();
            playersTXT.Remove(playersTXT.Length - 2);
            return playersTXT;
        }
        static private List<IPlayer> ConvertToPlayers(List<string> players)
        {
            List<IPlayer> completePlayers = new List<IPlayer>();
            foreach (string player in players)
            {
                IPlayer parsedPlayer = ConvertToPlayer(player);
                completePlayers.Add(parsedPlayer);
            }
            return completePlayers;
        }
        static private IPlayer ConvertToPlayer(string playerTXT)
        {
            var grouping = new Regex(@"^(\w+) (\d+)$");
            Match match = grouping.Match(playerTXT);
            string name = match.Groups[1].ToString();
            string winsString = match.Groups[2].ToString();
            int wins = int.Parse(winsString);
            return new Player(name, wins);
        }
        static private string[] FileToPlayerStrings(IReader reader)
        {       
            string fullFile = reader.ReadToEnd();
            return fullFile.Split("\n", System.StringSplitOptions.None).ToArray();
        }
    }
}