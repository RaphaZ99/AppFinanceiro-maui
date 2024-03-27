namespace AppFinanceiro.Core_.Domain
{
    public class Transaction
    {
        public TransactionType TransactionType { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Value { get; set; }
    }
}
