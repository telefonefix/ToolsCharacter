
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Entities.Person;

namespace Data.Repositories
{
    public class DbCharacterRepository : IDbCharacterRepository
    {
        protected CharactereContext _context;

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

        public void Add(Character character)
        {
            using (_context)
            {
                _context.Characters.Add(character);
                _context.SaveChanges();
            }
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
            throw new NotImplementedException();
        }

        public int GetId(string name, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
