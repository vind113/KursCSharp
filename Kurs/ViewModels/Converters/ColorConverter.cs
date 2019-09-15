using Kurs.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Kurs.ViewModels.Converters
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ShapeColors color)
            {
                switch (color)
                {
                    case ShapeColors.Red:
                        return Brushes.Red;
                    case ShapeColors.Green:
                        return Brushes.Green;
                    case ShapeColors.Blue:
                        return Brushes.Blue;
                    case ShapeColors.Black:
                        return Brushes.Black;
                }
            }

            //and now for something completely different
            return Brushes.Yellow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
