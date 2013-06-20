using System;
using System.Data;
using System.Data.Entity;

namespace UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;
        void Commit();
    }
}
