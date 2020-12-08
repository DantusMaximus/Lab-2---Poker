using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
class Reader: IReader{
    string fileName;
    public Reader(string fileName){this.fileName = fileName;}
        public void Read(string saveFileContent)
        {
            using(StreamWriter writer = new StreamWriter(fileName)){
               writer.Write(saveFileContent, fileName); 
            }
        }
    }
}