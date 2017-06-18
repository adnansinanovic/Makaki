using System.Globalization;
using System.Windows.Controls;

namespace Makaki.Ui.ValidationRules
{
    public class RequiredFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Unesite vrijednost.");

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Unesite vrijednost.");

            return ValidationResult.ValidResult;            
        }
    }
}
