using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class ShapeLine
    {
        public ShapePoint Start { get; }
        public ShapePoint End { get; }

        public ShapeLine(ShapePoint a, ShapePoint b)
        {
            this.Start = a;
            this.End = b;
        }

        public double Length
        {
            get
            {
                double dx = Start.X - End.X;
                double dy = Start.Y - End.Y;
                return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            }
        }

        private double A => End.Y - Start.Y;

        private double B => Start.X - End.Y;

        private double C => (Start.Y * (End.X - Start.X)) - (Start.X * (End.Y - Start.Y));

        private int CheckSide(ShapePoint point)
        {
            double result = (A * point.X) + (B * point.Y) + C;

            if (result > 0) return 1;
            else if (result < 0) return -1;
            else return 0;

        }

        public bool Crosses(ShapeLine line)
        {
            /*if (CheckSide(line.Start) * CheckSide(line.End) > 0
            || (line.CheckSide(Start) * line.CheckSide(End) > 0))
            {
                return false;
            }
            else
            {
                return true;
            }*/


            double denominator = (this.End.Y - this.Start.Y) * (line.End.X - line.Start.X) 
                               - (this.End.X - this.Start.X) * (line.End.Y - line.Start.Y);

            double t1 = ((this.Start.X - line.Start.X) * (line.End.Y - line.Start.Y) 
                      + (line.Start.Y - this.Start.Y) * (line.End.X - line.Start.X)) / denominator;

            if (double.IsInfinity(t1))
            {
                return false;
            }

            double t2 = ((line.Start.X - this.Start.X) * (this.End.Y - this.Start.Y) 
                      + (this.Start.Y - line.Start.Y) * (this.End.X - this.Start.X)) / -denominator;

            return ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));
        }
    }
}
