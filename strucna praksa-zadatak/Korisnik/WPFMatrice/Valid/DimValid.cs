using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WPFMatrice.Valid
{
    class DimValid : ValidationRule
    {
        public override ValidationResult Validate
        (object value, System.Globalization.CultureInfo cultureInfo)
        {
            double number = 0;
            try
            {
                number = Convert.ToInt32(value.ToString());  // Check for numeric value
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Morate uneti cifru!");
            }
           
            return new ValidationResult(true, null);
        }
    }
    
}
