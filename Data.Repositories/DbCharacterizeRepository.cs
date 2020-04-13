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

        public int Id { get; private set; }

        public CharactereContext Context { get { return _context; } }
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
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
            _context.Dispose();
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
            try
            {
                int id = GetAll<TEntity>().FirstOrDefault(t => t.Name == name).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
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

        public void Create<ICharacteristic>(T entity, ICharacteristic<T> charac, string name)
        {
            int id = GetId(entity, name);

            // Not found so add it
            if (id == 0)
            {
                entity.Name = name.ToUpper();                
                Add<T>(entity);
                id = GetId(entity, name);


                Save();
                // Return new Id
            }
            Id = id;
        }



        public void Create<ICharacteristic>(T entity, ICharacteristic<T> charac, string name, string feature)
        {
            int id = GetId(entity, name);


            // Not found so add it
            if (id == 0)
            {
                if (entity.GetType() == typeof(Skill))
                {
                    Skill skill = new Skill();
                    skill.Name = name;
                    skill.IdFeature = GetId<Feature>(new Feature(), feature);
                    Add<Skill>(skill);
                    Save();
                    id = GetId(skill, name);
                }
                else
                {
                    entity.Name = name;
                    Add<T>(entity);
                    Save();
                    id = GetId(entity, name);
                }
            }
            Id = id;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
