using System.Globalization;

namespace AppFinanceiro.Helpers
{
    public class TransactionFirtsLetterConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var transaction = (Core.Domain.Transaction)value;

            if (transaction is null)
                return "";

            return transaction.Name.Substring(0, 1).ToUpper();
                
 
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
