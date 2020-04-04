using Data.Context;
using Data.Entities.Characterize;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbCharacterizeRepository<T> : IDbCharacterizeRepository<T> where T : class, ICharacteristic<T>
    {
        protected CharactereContext _context;

        public CharactereContext Context { get { return _context; } }
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
            //throw new NotImplementedException();
            return _context.Set<TEntity>().Add(entity);

        }

        public TEntity Attach<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
            throw new NotImplementedException();
        }

        public TEntity AttachIfNot<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, ICharacteristic<TEntity>
        {
            DbSet<TEntity> entityDbSet = _context.Set<TEntity>();

            return entityDbSet;
        }

        public int GetId<TEntity>(TEntity entity, string name) where TEntity : class, ICharacteristic<TEntity>
        {
            return GetAll<TEntity>().FirstOrDefault(t => t.Name == name).Id;
        }



        public DbCharacterizeRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbCharacterizeRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;

        }

    }
}
