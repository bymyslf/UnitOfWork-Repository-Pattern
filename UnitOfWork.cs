using System;

namespace UnitOfWorkRepository
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork()
            : base()
        { }

        public UnitOfWork(string connectionString)
            : base(connectionString)
        { }

        public override IRepository<TEntity> RepositoryFor<TEntity>()
        {
            Type repositoryType = typeof(Repository<TEntity>);
            if (!repositoryCollection.Contains(repositoryType))
            {
                repositoryCollection.Add(new Repository<TEntity>(this));
            }

            return repositoryCollection[repositoryType] as Repository<TEntity>;
        }
    }
}