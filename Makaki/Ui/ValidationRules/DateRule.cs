using System;
using System.Globalization;
using System.Windows.Controls;

namespace Makaki.Ui.ValidationRules
{
    public class DateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                value = DateTime.Today;

            DateTime? dt = value as DateTime? ?? new DateTime();

            if (dt < new DateTime(1753,1,1)) //min possible date in mssql
                return new ValidationResult(false, "Datum je prenizak");

            if (dt > new DateTime(9999, 12, 31)) //max possible date in mssql
                return new ValidationResult(false, "Datum je previsok");

            return  ValidationResult.ValidResult;            
        }
    }
}
