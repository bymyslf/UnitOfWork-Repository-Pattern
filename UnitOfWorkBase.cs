using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace UnitOfWorkRepository
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected DbContext context;
        protected readonly KeyedByTypeCollection<object> repositoryCollection;

        public UnitOfWorkBase()
            : this(new DbContext("DefaultConnection"))
        { }

        public UnitOfWorkBase(DbContext context)
        {
            this.context = context;
            this.repositoryCollection = new KeyedByTypeCollection<object>();
        }

        public abstract IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;

        public void Commit()
        {
            this.context.SaveChanges();
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
