using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
    class Reader : IReader
    {
        string fileName;
        public Reader(string fileName) { this.fileName = fileName; }
        public string ReadToEnd()
        {
            if(!File.Exists(fileName)){
                throw new FileNotFoundException("savefile not found");
            }
            using (var stream = File.Open(fileName, FileMode.Open))
            using (var reader = new StreamReader(stream)){
            return reader.ReadToEnd();
            }           
        }
    }
}