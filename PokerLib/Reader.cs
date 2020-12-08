using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
    class Reader : IReader
    {
        Stream stream;
        string fileName;
        public Reader(string fileName) { this.fileName = fileName; }
        public string[] ReadAllLines()
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    var playerStrings = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        playerStrings.Add(line);
                    }
                    return playerStrings.ToArray();
                }
            }
        }
    }
}