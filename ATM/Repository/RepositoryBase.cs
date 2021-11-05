using ATM.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using static ATM.Repository.IRepositoryBase;

namespace ATM.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext _databaseContext { get; set; }
        public RepositoryBase(DatabaseContext repositoryContext)
        {
            this._databaseContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this._databaseContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._databaseContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
            _databaseContext.SaveChanges();
        }
        public void Update(T entity)
        {
            this._databaseContext.Set<T>().Update(entity);
            _databaseContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            this._databaseContext.Set<T>().Remove(entity);
            _databaseContext.SaveChanges();
        }
    }
}
