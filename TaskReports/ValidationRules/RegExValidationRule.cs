using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskReports.ValidationRules
{
    public class RegExValidationRule : ValidationRule
    {


        private Regex _Regex;



        public string Pattern
        {
            get => _Regex?.ToString();
            set => _Regex = value is null ? null : value == string.Empty ? null : new Regex(value);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {




            string str;
            return null;
          //  return _Regex.IsMatch(str)
            //    ? ValidationResult.ValidResult
              //  : new ValidationResult(false, errorContent)
        }



    }
}
