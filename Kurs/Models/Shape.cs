using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    abstract class AbstractShape
    {
        protected readonly List<ShapeLine> lines = new List<ShapeLine>();

        public ShapeColors Color { get; set; }
        public double Perimeter => lines.Sum(line => line.Length);

        public ReadOnlyCollection<ShapeLine> Lines => new ReadOnlyCollection<ShapeLine>(lines);

        public AbstractShape(ShapeColors color)
        {
            this.Color = color;
        }

        public bool Intersects(AbstractShape other)
        {
            return Lines.Any(line => other.Lines.Any(otherLine => line.Crosses(otherLine)));
        }
    }
}
