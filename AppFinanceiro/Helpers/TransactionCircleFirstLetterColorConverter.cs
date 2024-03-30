using System.Globalization;

namespace AppFinanceiro.Helpers
{
    public class TransactionCircleFirstLetterColorConverter : IValueConverter
    {
        private Random rnd = new Random();
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
              
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); ;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
