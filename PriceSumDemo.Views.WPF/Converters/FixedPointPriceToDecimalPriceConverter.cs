using System.Globalization;
using System.Windows.Data;

namespace PriceSumDemo.Views.WPF.Converters;

public class FixedPointPriceToDecimalPriceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int _value) return (_value / 100D).ToString("c2");
        throw new ArgumentException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}