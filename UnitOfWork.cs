using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace UnitOfWork
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        protected KeyedByTypeCollection<object> repositoriesCollection;
            
        public UnitOfWork()
            : this("DefaultConnection")
        { }

        public UnitOfWork(string connectionString)
            : base(connectionString)
        { }

        public IRepository<TEntity> RepositoryFor<TEntity>()
            where TEntity : class
        {
            if (!repositoriesCollection.Contains(typeof(IRepository<TEntity>))) 
            {
                repositoriesCollection.Add(new Repository<TEntity>(this));
            }

            return repositoriesCollection[typeof(IRepository<TEntity>)] as IRepository<TEntity>;
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