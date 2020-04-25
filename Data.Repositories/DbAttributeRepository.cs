using Data.Context;
using Data.Entities.Attribute;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class DbAttributeRepository<T> : IDbAttributeRepository<T> where T : class, IAttribute<T>
        //public class DbAttributeRepository<TCharacterize> : IDbAttributeRepository<TCharacterize> where TCharacterize : class, ICharacteristic<TCharacterize>
        //public class DbAttributeRepository<TCharacterize, TAtttibute> : IDbAttributeRepository<TCharacterize, TAtttibute> where TCharacterize : class, ICharacteristic<TCharacterize> where TAtttibute : class, IAttribute<TAtttibute>
    {

        #region <Attributes>
        protected CharactereContext _context;
        private readonly int _idCharacter;

        #endregion <Attributes>

        #region <Constructors>
        public DbAttributeRepository(T entity, int idCharactere, CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharactere;
        }

        public DbAttributeRepository(T entity, int idCharactere)
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharactere;
        }
        #endregion <Constructors>

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, IAttribute<TEntity>
        {
            DbSet<TEntity> entityDbSet = _context.Set<TEntity>();

            return entityDbSet;
        }
      
        private bool FoundEntity<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>
        {
            try
            {
                IQueryable<TEntity> query = GetAll<TEntity>().Where(t => t.IdCharactere == entity.IdCharactere && t.Id == entity.Id);
                return (query.Count() != 0);

            }
            catch (NullReferenceException)
            {
                return false;
            }
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

        private TEntity Add<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>
        {
            return _context.Set<TEntity>().Add(entity);
        }


        TEntity IDbAttributeRepository<T>.Add<TEntity>(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public void Create<TEntity>(TEntity attribute) where TEntity : class, IAttribute<TEntity>
        {
            if (!FoundEntity(attribute))
            {
                Add<TEntity>(attribute);
                Save();
            }
        }

        private void Save()
        {
            _context.SaveChanges();
        }
        #endregion

    }
}
