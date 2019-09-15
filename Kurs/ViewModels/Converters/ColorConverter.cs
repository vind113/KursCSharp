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
            if (value is Models.Colors color)
            {
                switch (color)
                {
                    case Models.Colors.Red:
                        return Brushes.Red;
                    case Models.Colors.Green:
                        return Brushes.Green;
                    case Models.Colors.Blue:
                        return Brushes.Blue;
                    case Models.Colors.Black:
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
