using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities.Enterprise;

namespace Data.Repositories
{
    public class DbGradeRepository : IDbGradeRepository
    {
        protected CharactereContext _context;

        public int Id { get; set; }

        public IQueryable<Grade> GetAll(bool noTracking = true)
        {
            DbSet<Grade> entityDbSet = _context.Set<Grade>();

            return entityDbSet;
        }

        public int GetId(string category, int quantity)
        {
            int id = GetAll().FirstOrDefault(g => g.Category == category && g.Quantity == quantity).Id;
            Id = id;
            return id;
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
        // ~DbGradeRepository() {
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


        public DbGradeRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbGradeRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
        }
        #endregion
    }
}
