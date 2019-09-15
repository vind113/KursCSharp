using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class Triangle : AbstractShape
    {
        public Triangle(Point a, Point b, Point c) : base(Colors.Black)
        { 
            lines.Add(new Line(a, b));
            lines.Add(new Line(b, c));
            lines.Add(new Line(c, a));
        }
    }
}
