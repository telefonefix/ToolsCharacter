﻿
using Data.Context;
using Data.Entities.Person;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbCharacterRepository : IDbCharacterRepository
    {
        protected CharactereContext _context;
        public int Id { get; private set; }

        public DbCharacterRepository(CharactereContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public DbCharacterRepository()
        {
            _context = new CharactereContext();
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public CharactereContext Context { get { return _context; } }


        private Character Add(Character character)        
        {
            return _context.Set<Character>().Add(character);
        }


        public void Create( string firstName, string lastName, string pseudo, EnumGender gender)
        {
            int id = GetId(firstName, lastName, pseudo);
            Character character = new Character();
            // Not found so add it
            if (id == 0)
            {
                character.FirstName  = firstName;
                character.LastName = lastName.ToUpper();
                character.Pseudo = pseudo.ToUpper();

                Add(character);
                _context.SaveChanges();
                // Return new Id
                id = GetId(firstName, lastName, pseudo);
            }
            Id = id;
        }

        public void Save()
        {
            _context.SaveChanges();
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

        public IQueryable<Character> GetAll(bool noTracking = true)
        {
            DbSet<Character> entityDbSet = _context.Set<Character>();

            return entityDbSet;
        }

        public int GetId(string firstName, string lastName, string pseudo)
        {
            return GetAll().FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName && t.Pseudo == pseudo).Id;
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
        // ~DbCharacterRepository() {
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
    }
}
