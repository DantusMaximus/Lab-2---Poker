using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class GameFactoryTest
    {
        [Test]
        public void Assert_NewGame_MakesNewGame()
        {
            var playerNames = new string[] {"Magdalena", "Evert", "Sara",
        "Skurt"};
            IPokerGame standardGame = GameFactory.NewGame(playerNames);
            var players = standardGame.Players;
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(playerNames[i], players[i].Name);
            }
        }





    }
}
