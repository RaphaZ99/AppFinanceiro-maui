using AppFinanceiro.Core.Domain;
using AppFinanceiro.Core.Interfaces.Base;


namespace AppFinanceiro.Dal.Repositories.Base
{
    public class BaseRepository : IBaseRepository<Transaction>
    {
        public List<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
