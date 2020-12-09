using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Poker.Lib.UnitTest
{
    public class ReaderTest
    {
        [Test]
        public void Assert_ReadToEnd_Throws404onFileNotExisting(){
            Reader reader = new Reader("con.txt");
            Assert.Throws(typeof(System.IO.FileNotFoundException),
            delegate { 
                reader.ReadToEnd();
            });
        }
    }
}