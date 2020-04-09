using Data.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbCorporationRepository : IDisposable
    {
        int Id { get; set; }

        IQueryable<Corporation> GetAll(bool noTracking = true);

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        TResult Execute<TResult>(string functionName, params object[] parameters);
        //void Add(Character character);
        void Create(string name);
        int GetId(string name);
    }
}
