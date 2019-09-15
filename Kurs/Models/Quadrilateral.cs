using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class Quadrilateral : AbstractShape
    {
        public Quadrilateral(Point a, Point b, Point c, Point d) : base(Colors.Red)
        { 
            Point localA = a;
            Point localB = b;
            Point localC = c;
            Point localD = d;

            Line firstLine = null;
            Line secondLine = null;
            Line thirdLine = null;
            Line fourthLine = null;

            while (firstLine == null && thirdLine == null)
            {
                Line firstTempLine = new Line(localA, localB);
                Line thirdTempLine = new Line(localC, localD);
                if (!firstTempLine.Crosses(thirdTempLine))
                {
                    firstLine = new Line(localA, localB);
                    thirdLine = new Line(localC, localD);
                }
                else
                {
                    Point swapTemp = localB;
                    localB = localC;
                    localC = localD;
                    localD = swapTemp;
                }
            }

            Line secondTempLine = new Line(localA, localC);
            Line fourthTempLine = new Line(localB, localD);

            if (!secondTempLine.Crosses(fourthTempLine))
            {
                secondLine = new Line(localA, localC);
                fourthLine = new Line(localB, localD);
            }
            else
            {
                secondLine = new Line(localB, localC);
                fourthLine = new Line(localA, localD);
            }

            lines.Add(firstLine);
            lines.Add(secondLine);
            lines.Add(thirdLine);
            lines.Add(fourthLine);
        }
    }
}
