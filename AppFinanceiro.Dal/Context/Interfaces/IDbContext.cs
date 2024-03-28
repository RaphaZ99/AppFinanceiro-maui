using LiteDB;

namespace AppFinanceiro.Dal.Context.Interfaces
{
    public interface IDbContext
    {
        LiteCollection<T> GetCollection<T>() where T : new();
    }
}
