using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanceiro.Core.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        public List<T> GetAll();
        public void Add(T item);
        public void Update(T item);
        public void Delete(T item);
        public void DeleteAll();
        public T GetById(int id);
    }
}
