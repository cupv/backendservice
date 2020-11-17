using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Infrastructure;

namespace API.Services.Infrastructure
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected IRepositoryBase<T> repository;
        protected ServiceBase(IRepositoryBase<T> _repository)
        {
            repository = _repository;
        }
        public T GetById(Guid Id)
        {
            return repository.Get(Id);
        }

        public IQueryable<T> GetAll(string[] expands)
        {
            return repository.GetAll(expands);
        }

        public void Create(T entity)
        {
            repository.Create(entity);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }

        public void Delete(T entity)
        {
            repository.Delete(entity);
        }
    }
}
