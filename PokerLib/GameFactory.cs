namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
            if (playerNames.Length > 5) { throw new System.Exception("Error: Too many players. At most 5 accepted."); }
            if (playerNames.Length < 2) { throw new System.Exception("Error: Too few players. At least 2 required."); }
            StandardGame standardGame = new StandardGame(playerNames);
            return standardGame;
        }

        public static IPokerGame LoadGame(string fileName)
        {
            StandardGame standardGame = new StandardGame(fileName);
            return standardGame;
        }
    }
}