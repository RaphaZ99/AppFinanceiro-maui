using LiteDB;

namespace AppFinanceiro.Core.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(BsonValue id);
        void Insert(T entity);
        bool Update(T entity);
        bool Delete(BsonValue id);
    }
}
