using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class ShapePoint : IEquatable<ShapePoint>
    {
        public double X { get; }
        public double Y { get; }

        public ShapePoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        public bool Equals(ShapePoint other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
