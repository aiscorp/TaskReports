using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace TaskReports.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return ((DateTime)value).ToString("dd.MM.yyyy");

            return true;
            //return (bool)value ? "Green" : "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }


    }

    public class IntToStringConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          => (string)parameter == "plusOne" ? ((int)value + 1).ToString() : value.ToString();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          => throw new NotImplementedException();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
         => $"{Convert(values[0], targetType, parameter, culture) as string} {values[1]}";

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
          => throw new NotImplementedException();
    }


}
