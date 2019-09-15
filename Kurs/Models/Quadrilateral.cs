using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Models
{
    class Quadrilateral : AbstractShape
    {
        public Quadrilateral(ShapePoint a, ShapePoint b, ShapePoint c, ShapePoint d) : base(ShapeColors.Red)
        { 
            ShapePoint localA = a;
            ShapePoint localB = b;
            ShapePoint localC = c;
            ShapePoint localD = d;

            ShapeLine firstLine = null;
            ShapeLine secondLine = null;
            ShapeLine thirdLine = null;
            ShapeLine fourthLine = null;

            while (firstLine == null && thirdLine == null)
            {
                ShapeLine firstTempLine = new ShapeLine(localA, localB);
                ShapeLine thirdTempLine = new ShapeLine(localC, localD);
                if (!firstTempLine.Crosses(thirdTempLine))
                {
                    firstLine = new ShapeLine(localA, localB);
                    thirdLine = new ShapeLine(localC, localD);
                }
                else
                {
                    ShapePoint swapTemp = localB;
                    localB = localC;
                    localC = localD;
                    localD = swapTemp;
                }
            }

            ShapeLine secondTempLine = new ShapeLine(localA, localC);
            ShapeLine fourthTempLine = new ShapeLine(localB, localD);

            if (!secondTempLine.Crosses(fourthTempLine))
            {
                secondLine = new ShapeLine(localA, localC);
                fourthLine = new ShapeLine(localB, localD);
            }
            else
            {
                secondLine = new ShapeLine(localB, localC);
                fourthLine = new ShapeLine(localA, localD);
            }

            lines.Add(firstLine);
            lines.Add(secondLine);
            lines.Add(thirdLine);
            lines.Add(fourthLine);
        }
    }
}
