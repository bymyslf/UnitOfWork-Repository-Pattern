using System;

namespace UnitOfWorkRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;
        void Commit();
    }
}
