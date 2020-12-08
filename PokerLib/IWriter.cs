using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
public interface IWriter{
    void Write(string saveFileContent);

}
}