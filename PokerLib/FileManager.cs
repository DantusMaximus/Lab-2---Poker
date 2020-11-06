using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
    class FileManager
    {
        //not relevant in current iteration
        private const string path = "";
        //not relevant in current iteration
        static public bool SaveGame(string fileName, List<IPlayer> players)
        {
            CreateSaveDirIfNonExistent();
            using(var writer = new StreamWriter(fileName))
            {
            string saveFile = ConvertToString(players);
            writer.Write(saveFile, fileName);
            return true;
            }
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
        static public List<IPlayer> LoadGame(string fileName)
        {
            string[] playersStrings = FileToPlayerStrings(fileName);
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
                    throw new System.Exception("Felaktigt filformat");
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
        static private string[] FileToPlayerStrings(string fileName)
        {
            using (var stream = File.Open(path + fileName, FileMode.Open))
            {
                var playerStrings = new List<string>();
                stream.Position = 0;
                var reader = new StreamReader(stream);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                   playerStrings.Add(line);
                }        
            return playerStrings.ToArray();
            }
        }
    }
}