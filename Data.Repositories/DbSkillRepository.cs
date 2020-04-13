using Data.Context;
using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbSkillRepository : IDbSkillRepository
    {
        protected CharactereContext _context;

        public int Id { get; private set; }


        public DbSkillRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbSkillRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public Skill Add(Skill skill)
        {
            return _context.Set<Skill>().Add(skill);
        }

        public TEntity Attach<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity AttachIfNot<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Skill> GetAll(bool noTracking = true)
        {
            DbSet<Skill> entityDbSet = _context.Set<Skill>();
            return entityDbSet;
        }

        public int GetId(string name)
        {
            try
            {
                int id = GetAll().FirstOrDefault(t => t.Name == name).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }
        public void Create(string name, string nameFeature)
        {
            DbCharacterizeRepository<Feature> feature = new DbCharacterizeRepository<Feature>();
                int id = GetId(name);

            int idFeature = feature.GetId<Feature>(new Feature(), nameFeature);
            Skill skill = new Skill();
            // Not found so add it
            if (id == 0)
            {
                skill.Name = name.ToUpper();
                skill.IdFeature = idFeature;
                Add(skill);
                Save();
                // Return new Id
                id = GetId(name);
            }
            Id = id;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~DbSkillRepository() {
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
        #endregion

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
