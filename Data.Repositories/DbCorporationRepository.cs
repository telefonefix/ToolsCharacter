using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities.Enterprise;

namespace Data.Repositories
{
    public class DbCorporationRepository : IDbCorporationRepository
    {
        protected CharactereContext _context;
        public int Id { get; set; }

        public DbCorporationRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
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
            throw new NotImplementedException();
        }

        public int GetId(string name)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
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

                Corporation corpo = Add(corporation);
                //_context.SaveChanges();
                // Return new Id
                id = corpo.IdCorporation;
                //id = GetId(name);
            }
            Id = id;
        }
        #endregion
    }
}
