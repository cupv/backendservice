using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public DbSet<T> dbSet;
        public TestContext dbContext = new FactoryContext().Init();
        public RepositoryBase()
        {
            dbSet = dbContext.Set<T>();
        }
        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            try
            {
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Record does not exist in the database ." + e);
            }

        }


        public IQueryable<T> GetAll(string[] expands = null)
        {
            var result = dbSet as IQueryable<T>;
            if (expands != null && expands.Any())
            {
                result = expands.Distinct().Aggregate(result, (current, expand) => current.Include(expand)).AsNoTracking();
            }
            return result;
        }

        public T Get(Guid Id)
        {
            if (Id == null)
            {
                throw new NotImplementedException();
            }
            return dbSet.Find(Id);
        }


        public void Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Record does not exist in the database ." + e);
            }
        }
    }
}
