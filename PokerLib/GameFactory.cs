namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
           // StandardGame standardGame = new StandardGame(playerNames);
            //return standardGame;
            return null;
        }

        public static IPokerGame LoadGame(string fileName)
        {
            //StandardGame standardGame = new StandardGame(fileName);
            //return standardGame;
            return null;
        }
    }
}