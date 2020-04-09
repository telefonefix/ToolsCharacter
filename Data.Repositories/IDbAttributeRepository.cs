﻿using Data.Entities.Attribute;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbAttributeRepository<T> : IDisposable where T : class, IAttribute<T>
    {
        IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, IAttribute<TEntity>;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>;


        TEntity Delete<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>;
        TEntity Attach<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>;
        TEntity AttachIfNot<TEntity>(TEntity entity) where TEntity : class, IAttribute<TEntity>;

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        TResult Execute<TResult>(string functionName, params object[] parameters);

        TEntity GetEntity<TEntity>(TEntity entity, int idPerson, int idCharacterize) where TEntity : class, IAttribute<TEntity>;
        //int GetId<TEntity>(TEntity entity, int idPerson, int idCharacterize) where TEntity : class, IAttribute<TEntity>;
    }
}