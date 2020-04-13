
using Data.Context;
using Data.Entities.Person;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    enum Position
    {
        Corporation,
        Grade
    }

    public class DbCharacterRepository : IDbCharacterRepository
    {
        #region Attibutes
        protected CharactereContext _context;

        
        // TODO : A laisser
        //private Position _position;
        #endregion Attibutes

        #region Private Methods

        private Character Add(Character character)
        {
            return _context.Set<Character>().Add(character);
        }


        // TODO : A garder pour le moment : Connaitre la position dans une corpo
        //private int? GetIdPosition(int id, Position position)
        //{
        //    int? idPosition = null;
        //    if (id != 0)
        //    {
        //        try
        //        {
        //            switch (position)
        //            {
        //                case Position.Corporation:
        //                    idPosition = GetAll().FirstOrDefault(t => t.Id == id).IdCorporation;
        //                    break;
        //                case Position.Grade:
        //                    idPosition = GetAll().FirstOrDefault(t => t.Id == id).IdGrade;
        //                    break;
        //                default:
        //                    idPosition = null;
        //                    break;
        //            }


        //        }
        //        catch (Exception)
        //        {
        //            idPosition = null;
        //        }
        //    }
        //    return idPosition;
        //}
        #endregion Private Methods

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





        public void Create(string firstName, string lastName, string pseudo, EnumGender gender, int? corpo, int? grade)
        {
            int id = GetId(firstName, lastName, pseudo);
            //int idCorpo = 

            Character character = new Character();
            // Not found so add it
            if (id == 0)
            {
                
                character.FirstName = firstName;
                character.LastName = lastName.ToUpper();
                character.Pseudo = pseudo.ToUpper();
                character.IdCorporation = corpo;
                character.IdGrade = grade;
                character.IdEthnic = 1;

                Add(character);
                Save();
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
            int id;
            try
            {
                id = GetAll().FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName && t.Pseudo == pseudo).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                id = 0;
            }
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
