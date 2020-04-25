using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbSkillRepository : IDisposable
    {
        IQueryable<Skill> GetAll(bool noTracking = true);
        Skill Add(Skill skill);

        TEntity Delete<TEntity>(TEntity entity);
        TEntity Attach<TEntity>(TEntity entity);
        TEntity AttachIfNot<TEntity>(TEntity entity);

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        TResult Execute<TResult>(string functionName, params object[] parameters);

        int GetId(string name);
    }
}
