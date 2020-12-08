using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest{
    class FileManagerTest{
        [SetUp]
        public void SetUp(){}

        class MockWriter : IWriter
        {
            public string saveFileContent;
            public void Write(string saveFileContent)
            {
                this.saveFileContent = saveFileContent;
            }
        }

        [Test]
        public void Assert_SaveGame_WritesCorrectly(){
            Player player1 = new Player("proplayer", 0);
            Player player2 = new Player("noobplayer", int.MaxValue);
            var players = new List<IPlayer>(){player1, player2};
            MockWriter writer = new MockWriter();
            FileManager.SaveGame(writer, players);
            string expected = $"proplayer 0\nnoobplayer {int.MaxValue}\n";
            Assert.AreEqual(expected, writer.saveFileContent);
        }


        static public List<ICard> ToCards(string text){
            return ScoreLogicTest.ToCards(text);
        }
    }



}