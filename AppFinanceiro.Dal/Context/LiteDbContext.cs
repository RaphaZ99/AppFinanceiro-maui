using AppFinanceiro.Dal.Context.Interfaces;
using LiteDB;

namespace AppFinanceiro.Dal.Context
{
    public class LiteDbContext : IDbContext
    {
        private readonly LiteDatabase _database;

        public LiteDbContext()
        {
            _database = new LiteDatabase("Filename=C://users/finance.db;Connection=Shared");
        }

        public LiteCollection<T> GetCollection<T>() where T : new()
        {
            return (LiteCollection<T>)_database.GetCollection<T>();
        }
    }
}
