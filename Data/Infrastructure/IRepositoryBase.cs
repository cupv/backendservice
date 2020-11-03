using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(Guid id);

        IQueryable<T> GetAll(string[] expands);

    }
}
