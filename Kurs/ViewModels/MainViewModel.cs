using Kurs.Models;
using Kurs.Utils;
using Kurs.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kurs.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly List<AbstractShape> shapes = new List<AbstractShape>();

        public List<ShapeLineViewModel> Lines => shapes
            .SelectMany(shape => shape.Lines.Select(line => new ShapeLineViewModel(line, shape.Color)))
            .ToList();

        public ICommand InitCommand { get; }
        public ICommand PlainDrawCommand { get; }
        public ICommand ColorDrawCommand { get; }
        public ICommand IntersectCommand { get; }
        public ICommand ExitCommand { get; }

        private bool twoLargestIntersect = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            InitCommand = new Command(() =>
            {
                shapes.Clear();
                FileDataReader.ReadDataFile(@"E:\Other\Новая папка\kurs\Debug\f.txt")
                    .Select(line => DataParser.ParseDataLine(line))
                    .ToList()
                    .ForEach(data =>
                    {
                        if (data.Count == 6)
                        {
                            ShapePoint a = new ShapePoint(data[0], data[1]);
                            ShapePoint b = new ShapePoint(data[2], data[3]);
                            ShapePoint c = new ShapePoint(data[4], data[5]);

                            shapes.Add(new Triangle(a, b, c));
                        }
                        else if (data.Count == 8)
                        {
                            ShapePoint a = new ShapePoint(data[0], data[1]);
                            ShapePoint b = new ShapePoint(data[2], data[3]);
                            ShapePoint c = new ShapePoint(data[4], data[5]);
                            ShapePoint d = new ShapePoint(data[6], data[7]);

                            shapes.Add(new Quadrilateral(a, b, c, d));
                        }
                    });
            });

            PlainDrawCommand = new Command(() =>
            {
                OnPropertyChanged(nameof(Lines));
            });

            ColorDrawCommand = new Command(() =>
            {
                //mainCanvas.Children.Clear();

                double largestQuadPerimeter = shapes
                    .FindAll(shape => shape is Quadrilateral)
                    .OrderByDescending(quad => quad.Perimeter)
                    .First().Perimeter;

                List<Triangle> halfPerimeterTriangles = shapes
                    .FindAll(shape => shape is Triangle && shape.Perimeter < largestQuadPerimeter / 2)
                    .Cast<Triangle>().ToList();

                halfPerimeterTriangles.ForEach(triangle => triangle.Color = ShapeColors.Blue);

                List<Triangle> twoLargestTriangles = halfPerimeterTriangles
                    .OrderByDescending(triangle => triangle.Perimeter)
                    .Take(2).ToList();

                twoLargestTriangles.ForEach(triangle => triangle.Color = ShapeColors.Green);
                if (twoLargestTriangles.Count == 2)
                {
                    twoLargestIntersect = twoLargestTriangles[0].Intersects(twoLargestTriangles[1]);
                }

                OnPropertyChanged(nameof(Lines));
            });

            IntersectCommand = new Command(() =>
            {
                MessageBox.Show(twoLargestIntersect.ToString());
            });

            ExitCommand = new Command(() =>
            {
                Environment.Exit(0);
            });
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
