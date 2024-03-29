namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
            StandardGame standardGame = new StandardGame(playerNames);
            return standardGame;
        }

        public static IPokerGame LoadGame(string fileName)
        {
            return new StandardGame(new Reader(fileName));            
        }
    }
}