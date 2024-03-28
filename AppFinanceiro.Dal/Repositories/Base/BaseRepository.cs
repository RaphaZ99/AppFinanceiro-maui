using AppFinanceiro.Core.Interfaces.Base;
using AppFinanceiro.Dal.Context.Interfaces;
using LiteDB;

namespace AppFinanceiro.Dal.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        private IDbContext _context;
        protected readonly LiteCollection<T> _collection;
        public BaseRepository(IDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>();

        }
        public virtual IEnumerable<T> GetAll()
        {
            return _collection.FindAll();
        }

        public virtual T GetById(BsonValue id)
        {
            return _collection.FindById(id);
        }

        public virtual void Insert(T entity)
        {
            _collection.Insert(entity);
        }

        public virtual bool Update(T entity)
        {
            return _collection.Update(entity);
        }

        public virtual bool Delete(BsonValue id)
        {
            return _collection.Delete(id);
        }

    }
}
