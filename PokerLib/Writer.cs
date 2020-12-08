using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
class Writer: IWriter{
    string fileName;
    public Writer(string fileName){this.fileName = fileName;}
        public void Write(string saveFileContent)
        {
            using(StreamWriter writer = new StreamWriter(fileName)){
               writer.Write(saveFileContent, fileName); 
            }
        }
    }
}