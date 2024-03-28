using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace AppFinanceiro.Dal.Context.Interfaces
{
    public interface IDbContext
    {
        LiteCollection<T> GetCollection<T>() where T : new();
    }
}
