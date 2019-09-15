using Kurs.Models;

namespace Kurs.ViewModels.Commands
{
    class LineViewModel
    {
        private readonly Line inner;

        public LineViewModel(Line line, Colors color)
        {
            inner = line;
            this.Color = color;
        }

        public double X1 => inner.Start.X;
        public double Y1 => inner.Start.Y;
        public double X2 => inner.End.X;
        public double Y2 => inner.End.Y;

        public Colors Color { get; }
    }
}
