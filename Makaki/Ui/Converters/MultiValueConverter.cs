using System;
using System.Globalization;
using System.Windows.Data;

namespace Makaki.Ui.Converters
{
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object[] objects = value as object[];

            if (objects != null)
                return objects;

            return new[] {value};
        }
    }
}
