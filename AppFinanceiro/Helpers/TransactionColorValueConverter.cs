using System.Globalization;

namespace AppFinanceiro.Helpers
{
    public class TransactionColorValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var transaction = (Core.Domain.Transaction)value;

            if (transaction is null)
                return Colors.Black;

            var color = transaction.TransactionType == Core.Enums.TransactionType.Income ?
               Color.FromRgb(147, 158, 90) :
               Colors.Red;

            return color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
