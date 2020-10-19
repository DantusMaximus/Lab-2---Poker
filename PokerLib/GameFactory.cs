namespace Poker.Lib
{
    public static class GameFactory
    {
        public static Game NewGame(string[] playerNames)
        {
            Game game = new Game(playerNames);
            return game;
        }

        public static Game LoadGame(string fileName)
        {

        }
    }
}