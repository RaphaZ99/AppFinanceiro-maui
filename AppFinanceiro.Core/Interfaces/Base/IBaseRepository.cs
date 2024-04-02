using LiteDB;

namespace AppFinanceiro.Core.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(BsonValue id);
        Task<T> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(BsonValue id);
    }
}
