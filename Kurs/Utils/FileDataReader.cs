using System.Collections.Generic;
using System.IO;

namespace Kurs.Utils
{
    static class FileDataReader
    {
        public static List<string> ReadDataFile(string filePath)
        {
            try
            {
                return new List<string>(File.ReadAllLines(filePath));
            }
            catch (IOException)
            {
                return new List<string>();
            }
        }
    }
}
