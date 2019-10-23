using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace TaskReports.Converters
{
    public class RgbToColorConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty((string)value))
                return (SolidColorBrush)new BrushConverter().ConvertFrom(value);

            return new SolidColorBrush(Colors.Black);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
