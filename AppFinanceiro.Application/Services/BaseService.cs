using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFinanceiro.Core.Interfaces.Base;

namespace AppFinanceiro.Application.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task DeleteById(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> Save(T entity)
        {
            return await _repository.Insert(entity);
        }

        public async Task<T> Update(T entity)
        {
            var result = await _repository.Update(entity);
            if (!result)
                throw new Exception("Failed to update entity.");

            return entity;
        }
    }
}
