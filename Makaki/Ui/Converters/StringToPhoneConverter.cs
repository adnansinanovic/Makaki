using System;
using System.Globalization;
using System.Windows.Data;

namespace Makaki.Ui.Converters
{
    public class StringToPhoneConverter    : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            //retrieve only numbers in case we are dealing with already formatted phone no
            string phoneNo = value.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);


            int cnt = phoneNo.Length;
            const int step = 3;

            while (cnt > step)
            {
                int index = cnt - 3;

                if (index > 0)
                    phoneNo = phoneNo.Insert(index, "-");

                cnt = index;
            }            
        
            return phoneNo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
