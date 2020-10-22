namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
            if(playerNames.Length > 5){ throw new System.Exception("Argt felmeddelande");}
            if(playerNames.Length < 2){ throw new System.Exception("Argt felmeddelande");}
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