using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Kurs.Utils
{
    static class DataParser
    {
        private readonly static Regex regex = new Regex(@"=\d+");

        public static List<double> ParseDataLine(string line)
        {
            return regex.Matches(line).Cast<Match>().Select(match =>
            {
                return double.TryParse(match.Value.Substring(1), out double value) ? value : 0;
            }).ToList();
        }
    }
}
