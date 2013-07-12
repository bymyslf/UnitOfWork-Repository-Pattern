using System;
using System.Data.Entity;

namespace UnitOfWorkRepository
{
    public interface IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;
        void Commit();
    }
}
