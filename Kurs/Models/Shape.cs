using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kurs.Models
{
    abstract class AbstractShape
    {
        protected readonly List<Line> lines = new List<Line>();

        public Colors Color { get; set; }
        public double Perimeter => lines.Sum(line => line.Length);

        public ReadOnlyCollection<Line> Lines => new ReadOnlyCollection<Line>(lines);

        public AbstractShape(Colors color)
        {
            this.Color = color;
        }

        public bool Intersects(AbstractShape other)
        {
            return Lines.Any(line => other.Lines.Any(otherLine => line.Crosses(otherLine)));
        }
    }
}
