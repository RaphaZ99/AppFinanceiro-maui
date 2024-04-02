using AppFinanceiro.Core.Domain;
using AppFinanceiro.Core.Interfaces;
using AppFinanceiro.Dal.Context.Interfaces;
using AppFinanceiro.Dal.Repositories.Base;

namespace AppFinanceiro.Dal.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbContext context) : base(context)
        {
        }
         
    }
}
