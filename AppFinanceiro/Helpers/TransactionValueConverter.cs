using System.Globalization;

namespace AppFinanceiro.Helpers
{
    public class TransactionValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var transaction = (Core.Domain.Transaction)value;

            if (transaction is null)
                return "";

            var valueConvertetText = transaction.TransactionType == Core.Enums.TransactionType.Income ?
                transaction.Value.ToString("C") :
                 $"- {transaction.Value.ToString("C")}";

            return valueConvertetText;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
