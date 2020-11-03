using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services.Infrastructure
{
    public interface IServiceBase<T> where T : class
    {
        T GetById(Guid Id);
        IQueryable<T> GetAll(string[] expands);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
