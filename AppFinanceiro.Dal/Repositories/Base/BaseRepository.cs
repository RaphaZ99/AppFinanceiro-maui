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

        public async Task<List<T>> GetAll()
        {
            return  _collection.FindAll().ToList();
        }

        public async Task<T> GetById(BsonValue id)
        {
            return _collection.FindById(id);
        }

        public async Task<T> Insert(T entity)
        {
           _collection.Insert(entity);

            return entity;
        }

        public async Task<bool> Update(T entity)
        {
            return _collection.Update(entity);
        }

        public async Task<bool> Delete(BsonValue id)
        {
            return _collection.Delete(id);
        }
         
    }
}
