using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace UnitOfWork
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        protected KeyedByTypeCollection<object> repositoryCollection;
            
        public UnitOfWork()
            : this("DefaultConnection")
        { }

        public UnitOfWork(string connectionString)
            : base(connectionString)
        {
            this.repositoryCollection = new KeyedByTypeCollection<object>();
        }

        public IRepository<TEntity> RepositoryFor<TEntity>()
            where TEntity : class
        {
            Type repositoryType = typeof(Repository<TEntity>);
            if (!repositoryCollection.Contains(repositoryType))
            {
                repositoryCollection.Add(new Repository<TEntity>(this));
            }

            return repositoryCollection[repositoryType] as Repository<TEntity>;
        }

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