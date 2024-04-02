namespace AppFinanceiro.Application.Services.Base
{
    public interface IBaseService<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task DeleteById(int id);
         
    }
}
