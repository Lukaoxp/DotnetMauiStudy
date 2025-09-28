using System.Globalization;

namespace Converters.Converters
{
    public class NotaColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var nota = (double)value;
            return nota >= 7.0 ? Colors.Blue : Colors.Red;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
