using Data.Context;
using Data.Entities.Attribute;
using Data.Entities.Characterize;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{

    //public class DbAttributeRepository<T> : IDbAttributeRepository<T> where T : class, IAttribute<T>
    public class DbAttributeRepository<TCharacterize> : IDbAttributeRepository<TCharacterize> where TCharacterize : class, ICharacteristic<TCharacterize>
        //public class DbAttributeRepository<TCharacterize, TAtttibute> : IDbAttributeRepository<TCharacterize, TAtttibute> where TCharacterize : class, ICharacteristic<TCharacterize> where TAtttibute : class, IAttribute<TAtttibute>
    {
        protected CharactereContext _context;

        //public TAtttibute GetAttributeEntity<TCharacterize, TAtttibute>(TCharacterize entity) where TCharacterize : class, IDbAttributeRepository<T> where TAtttibute : class, IDbAttributeRepository<TEntity>
        //{
        //    switch (entity)
        //    {
        //        case Feature f:
        //            return AttributeFeature();
        //            break;
        //        default:
        //            break;
        //    }

        //    return

        //}


        public DbAttributeRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbAttributeRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>
        {
            //throw new NotImplementedException();
            return _context.Set<TEntity>().Add(entity);

        }


        //TEntity IDbAttributeRepository<TEntity>.Attach<TEntity>(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //TEntity IDbAttributeRepository<T>.AttachIfNot<TEntity>(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //TEntity IDbAttributeRepository<T>.Delete<TEntity>(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //IQueryable<TEntity> IDbAttributeRepository<T>.GetAll<TEntity>(bool noTracking)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<TAttribute> GetAll<TCharac,TAttribute>(TCharac entity,bool noTracking = true) where TCharac : class, ICharacteristic<TCharac> where TAttribute : class,IAttribute<TAttribute>
        //{
        //    DbSet<TAttribute> entityDbSet = _context.Set<TAttribute>();

        //    return entityDbSet;

        //    //switch (entity)
        //    //{
        //    //    case Feature feature:
        //    //        //DbSet<TAttribute> entityDbSet = _context.Set<TAttribute>();
        //    //        DbSet<AttributeFeature> entityDbSet = _context.Set<AttributeFeature>();
        //    //        //return entityDbSet.SelectMany<TCharac, TAttribute>();

        //    //        var query<Attribute = entityDbSet.Select(af => af.Id != 0 && af.IdCharactere != 0);
        //    //        return query;

        //    //    //return entityDbSet.Select<AttributeFeature>(;

        //    //    default:
        //    //        break;
        //    //}
        //    //return null;


        //    //DbSet<TEntity> entityDbSet = _context.Set<TEntity>();

        //    //return entityDbSet;
        //}

        public TResult GetEntity<TSource>(TSource entity, int idPerson, int idCharacterize) where TSource : class, ICharacteristic<TSource> where TResult : class, IAttribute<TResult>
        {
            //try
            //{
            var query = GetAll<TSource>().FirstOrDefault(t => t.IdCharactere == idPerson && t.Id == idCharacterize);
            //if (query != null)
            return query;
            //}
            //catch (NullReferenceException)
            //{
            //    return 0;
            //}
        }

        private IQueryable<TResult> GetAll<TSource, TResult>() where TSource : class, ICharacteristic<TSource> where TResult : class, IAttribute<TResult>
        {
            DbSet<TResult> entityDbSet = _context.Set<TResult>();
            return entityDbSet;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                    _context.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~DbAttributeRepository() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        //public void Create<ICharacteristic>(T entity, ICharacteristic<T> charac, string name)
        public void Create<IAttribute>(T entity, IAttribute<T> attribute, int personId, int id, int value)
        {

            var query = GetEntity<T>(entity, personId, id);

            if (query == null)
            {
                entity.IdCharactere = personId;
                entity.Id = id;
                entity.Multiplier = 1;
                entity.Acquired = 0;
                entity.Value = value;

                Add<T>(entity);
                Save();
            }

            //_context.
            //var toto = (from st in _context.Entry(entity) where entity.IdCharactere == personId select entity.Id);

            //using (_context)
            //{
            //string table = entity.GetType().Name + "s";

            //string sql = string.Format("SELECT Id FROM {0} WHERE Name = @Name", table);

            //int result = _context.Database.SqlQuery<int>(sql, new SqlParameter("@Name", name)).FirstOrDefault();

            //// TODO : Voir pour les points acquis apres
            //if (result == 0)
            //{
            //entity.IdCharactere = personId;
            //entity.Id = id;
            //entity.Multiplier = 1;
            //entity.Acquired = 0;
            //entity.Value = value;

            //Add<T>(entity);
            //    result = _context.Database.SqlQuery<int>(sql, new SqlParameter("@Name", name)).FirstOrDefault();
            //}



            //_dbRepository.Context.SaveChanges();

            //}
        }
        #endregion

        private int GetMultiplier()
        {
            return 0;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        IQueryable<TEntity> IDbAttributeRepository<TCharacterize, TAtttibute>.GetAll<TEntity>(bool noTracking)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize, TAtttibute>.Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize, TAtttibute>.Attach<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize, TAtttibute>.AttachIfNot<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IDbAttributeRepository<TCharacterize>.GetAll<TEntity>(bool noTracking)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize>.Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize>.Attach<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IDbAttributeRepository<TCharacterize>.AttachIfNot<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
