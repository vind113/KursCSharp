using System;

namespace Kurs.Models
{
    class Line
    {
        public Point Start { get; }
        public Point End { get; }

        public Line(Point a, Point b)
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

        public bool Crosses(Line line)
        {
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
