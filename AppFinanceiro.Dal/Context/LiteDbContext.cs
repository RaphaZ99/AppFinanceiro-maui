using AppFinanceiro.Dal.Context.Interfaces;
using LiteDB;

namespace AppFinanceiro.Dal.Context
{
    public class LiteDbContext : IDbContext
    {
        private readonly LiteDatabase _database;

        public LiteDbContext(string databasePath)
        {
            _database = new LiteDatabase(databasePath);
        }

        public LiteCollection<T> GetCollection<T>() where T : new()
        {
            return (LiteCollection<T>)_database.GetCollection<T>();
        }
    }
}
