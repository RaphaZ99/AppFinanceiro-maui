using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanceiro.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public decimal Value { get; set; }
    }
}
