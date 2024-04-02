using AppFinanceiro.Application.Services.Base;
using AppFinanceiro.Application.Services.Interfaces;
using AppFinanceiro.Core.Domain;
using AppFinanceiro.Core.Interfaces;

namespace AppFinanceiro.Application.Services
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _repository;
        public TransactionService(ITransactionRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
