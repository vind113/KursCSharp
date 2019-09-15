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
        private const string dataFilePath = @"E:\Other\Новая папка\kurs\Debug\f.txt";
        private readonly List<AbstractShape> shapes = new List<AbstractShape>();

        public List<LineViewModel> Lines => shapes
            .SelectMany(shape => shape.Lines.Select(line => new LineViewModel(line, shape.Color)))
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
                FileDataReader.ReadDataFile(dataFilePath)
                    .Select(line => DataParser.ParseDataLine(line))
                    .ToList()
                    .ForEach(data =>
                    {
                        if (data.Count == 6)
                        {
                            Models.Point a = new Models.Point(data[0], data[1]);
                            Models.Point b = new Models.Point(data[2], data[3]);
                            Models.Point c = new Models.Point(data[4], data[5]);

                            shapes.Add(new Triangle(a, b, c));
                        }
                        else if (data.Count == 8)
                        {
                            Models.Point a = new Models.Point(data[0], data[1]);
                            Models.Point b = new Models.Point(data[2], data[3]);
                            Models.Point c = new Models.Point(data[4], data[5]);
                            Models.Point d = new Models.Point(data[6], data[7]);

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
                double largestQuadPerimeter = shapes
                    .FindAll(shape => shape is Quadrilateral)
                    .OrderByDescending(quad => quad.Perimeter)
                    .First().Perimeter;

                List<Triangle> halfPerimeterTriangles = shapes
                    .FindAll(shape => shape is Triangle && shape.Perimeter < largestQuadPerimeter / 2)
                    .Cast<Triangle>().ToList();

                halfPerimeterTriangles.ForEach(triangle => triangle.Color = Colors.Blue);

                List<Triangle> twoLargestTriangles = halfPerimeterTriangles
                    .OrderByDescending(triangle => triangle.Perimeter)
                    .Take(2).ToList();

                twoLargestTriangles.ForEach(triangle => triangle.Color = Colors.Green);
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
