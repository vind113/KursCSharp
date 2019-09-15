using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class Triangle : AbstractShape
    {
        public Triangle(ShapePoint a, ShapePoint b, ShapePoint c) : base(ShapeColors.Black)
        { 
            lines.Add(new ShapeLine(a, b));
            lines.Add(new ShapeLine(b, c));
            lines.Add(new ShapeLine(c, a));
        }
    }
}
