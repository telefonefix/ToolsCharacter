using Data.Context;
using Data.Entities.Person;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbCharacterRepository
    {
        IQueryable<Character> GetAll(bool noTracking = true);
       
        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        TResult Execute<TResult>(string functionName, params object[] parameters);
        void Add(Character character);

        int GetId(string name, string lastName);
    }
}
