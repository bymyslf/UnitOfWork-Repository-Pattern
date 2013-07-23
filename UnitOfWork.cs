using System;
using System.Data.Entity;

namespace UnitOfWorkRepository
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork()
            : base()
        { }

        public UnitOfWork(DbContext context)
            : base(context)
        { }

        public override IRepository<TEntity> RepositoryFor<TEntity>()
        {
            Type repositoryType = typeof(Repository<TEntity>);
            if (!repositoryCollection.Contains(repositoryType))
            {
                repositoryCollection.Add(new Repository<TEntity>(this.context));
            }

            return repositoryCollection[repositoryType] as Repository<TEntity>;
        }
    }
}