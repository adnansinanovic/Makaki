using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace Makaki.Ui.ValidationRules
{
    public class StringIsNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return ValidationResult.ValidResult;

            return value.ToString().Any(c => !char.IsNumber(c)) ? new ValidationResult(false, "Unesite broj") : ValidationResult.ValidResult;
        }
    }
}
