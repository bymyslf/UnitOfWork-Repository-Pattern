using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace UnitOfWorkRepository
{
    public abstract class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        protected readonly KeyedByTypeCollection<object> repositoryCollection;

        protected UnitOfWorkBase()
            : this("DefaultConnection")
        { }

        protected UnitOfWorkBase(string connectionString)
            : base(connectionString)
        {
            this.repositoryCollection = new KeyedByTypeCollection<object>();
        }

        public abstract IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;

        public void Commit()
        {
            this.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
