using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Poker
{
public interface IReader{
    void Read(string saveFileContent);

}
}