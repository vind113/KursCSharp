using Kurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.ViewModels.Commands
{
    class ShapeLineViewModel
    {
        private readonly ShapeLine inner;

        public ShapeLineViewModel(ShapeLine line, ShapeColors color)
        {
            inner = line;
            this.Color = color;
        }

        public double X1 => inner.Start.X;
        public double Y1 => inner.Start.Y;
        public double X2 => inner.End.X;
        public double Y2 => inner.End.Y;

        public ShapeColors Color { get; }
    }
}
