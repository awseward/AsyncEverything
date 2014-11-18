using System;
using System.Windows.Data;

namespace AsyncEverythingWpf
{
    public class NumberMatchingConverter : IValueConverter
    {
        public int ValueToMatch { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int) value == ValueToMatch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
