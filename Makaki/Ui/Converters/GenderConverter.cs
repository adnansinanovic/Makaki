using System;
using System.Globalization;
using System.Windows.Data;

namespace Makaki.Ui.Converters
{
    public class GenderConverter : IValueConverter
    {
        private string m = "Muški";
        private string f = "Ženski";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "-";

            if (value.ToString() == "M")
                return m;

            if (value.ToString() == "F")
                return f;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;            

            if (value.ToString() == m)
                return "M";

            if (value.ToString() == f)
                return "F";

            return value;
        }
    }
}
