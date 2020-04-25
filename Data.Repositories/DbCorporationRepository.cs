using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities.Attribute;
using Data.Entities.Enterprise;

namespace Data.Repositories
{
    public class DbCorporationRepository : IDbCorporationRepository
    {
        protected CharactereContext _context;
        private int _idCharacter;

        public int Id { get; set; }

        public DbCorporationRepository(CharactereContext context,int idCharacter)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharacter;
        }

        public DbCorporationRepository(int idCharacter)
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharacter;
        }
        public DbCorporationRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;            
        }


        private Corporation Add(Corporation corporation)
        {
            return _context.Set<Corporation>().Add(corporation);
        }

        private AttributeResource Add(AttributeResource attribute)
        {
            return _context.Set<AttributeResource>().Add(attribute);

        }
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

        public IQueryable<Corporation> GetAll(bool noTracking = true)
        {
            DbSet<Corporation> entityDbSet = _context.Set<Corporation>();

            return entityDbSet;
        }

        public int GetId(string name)
        {
            try
            {
                int id = GetCorporations().FirstOrDefault(t => t.Name == name).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                _disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~DbCorporationRepository() {
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

        public void Create(string name)
        {
            int id = GetId(name);
            Corporation corporation = new Corporation();
            // Not found so add it
            if (id == 0)
            {
                corporation.Name = name;
                corporation.IsGang = false;
                corporation.Color = "Yellow";
                //Add(corporation);

                Corporation corpo = Add(corporation);
                Save();
                // Return new Id
                //id = corpo.IdCorporation;
                id = GetId(name);
            }
            Id = id;
        }

        public void CreateResource(string name,int value)
        {
            int id = GetId(name);
            if (id == 0)
            {
                Corporation corporation = new Corporation
                {
                    Name = name,
                    IsGang = false,
                    Color = "Yellow"
                };
                //Add(corporation);

                Corporation corpo = Add(corporation);
                Save();              
                id = GetId(name);
            }
            Id = id;
            Mapper(value);

        }



        private IEnumerable<Corporation> GetCorporations()
        {

            DbSet<Corporation> entityDbSet = _context.Set<Corporation>();

            return entityDbSet;
        }

        private IQueryable<AttributeResource> GetAttributes()
        {

            DbSet<AttributeResource> entityDbSet = _context.Set<AttributeResource>();

            return entityDbSet;
        }

        private bool FoundResource(AttributeResource resource)
        {
            try
            {
                IQueryable<AttributeResource> query = GetAttributes().Where(t => t.Id == resource.Id && t.IdCharactere == resource.IdCharactere);
                return (query.Count() != 0);

            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        private void Mapper(int value)
        {
            AttributeResource resource = new AttributeResource()
            {
                Id = this.Id,
                IdCharactere = _idCharacter,
                Value = value
            };

            if (!FoundResource(resource))
            {
                Add(resource);
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
