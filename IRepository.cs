using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace MedFinderWebApplication.DataAccess
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        DbSet<TEntity> Items { get; }
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetByID(int id);
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
