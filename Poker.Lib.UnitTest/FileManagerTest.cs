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
          class MockReader : IReader
        {
            string fileContent;
            public MockReader(string  fileContent){
                this.fileContent = fileContent;
            }
            public string ReadToEnd(){
                return fileContent;
            }
        }
        [Test]
        public void Assert_LoadGame_LoadsCorrectly(){
            string fileContent = $"Hasse 2\nTage {int.MaxValue}";
            IReader reader = new MockReader(fileContent);
            
            List<IPlayer> resultingPlayers = FileManager.LoadGame(reader);
            
            Assert.AreEqual(2, resultingPlayers.Count());
            Assert.AreEqual("Hasse", resultingPlayers[0].Name);
            Assert.AreEqual(2, resultingPlayers[0].Wins);
            Assert.AreEqual("Tage", resultingPlayers[1].Name);
            Assert.AreEqual(int.MaxValue, resultingPlayers[1].Wins);            
        }
        [Test]
        public void Assert_LoadGame_SkipsLineOnEmptyPlayerLine(){
            string fileContent = "Hasse 2\n\nBob 1337";
            
            IReader reader = new MockReader(fileContent);
           
                List<IPlayer> resultingPlayers = FileManager.LoadGame(reader);                    
                Assert.AreEqual(2, resultingPlayers.Count());
                Assert.AreEqual("Bob", resultingPlayers[1].Name);            
        }
        [Test]
        public void Assert_LoadGame_ThrowsOnCorruptedSaveFile(
            [Values(
                    "Hasse\nBob 1337",
                    "Hasse femtiofyra\nBob 1337",
                    "Hasse femtiofyra\nBob 1337\n%&#"
                )] string fileContent
        ){

            IReader reader = new MockReader(fileContent);                               
            Assert.Throws(     typeof(System.Exception), delegate{
               List<IPlayer> resultingPlayers = FileManager.LoadGame(reader);
            });
        }

        static public List<ICard> ToCards(string text){
            return ScoreLogicTest.ToCards(text);
        }
    }



}