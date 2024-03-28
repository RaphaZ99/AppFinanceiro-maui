using AppFinanceiro.Core.Domain.Base;
using AppFinanceiro.Core.Enums;

namespace AppFinanceiro.Core.Domain
{
    public class Transaction : EntityBase
    {
        public TransactionType TransactionType { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Value { get; set; }
    }
}
