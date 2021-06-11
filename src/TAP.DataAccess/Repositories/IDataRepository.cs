using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TAP.Core;

namespace TAP.DataAccess.Repositories
{
    public interface IDataRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase;

        void Insert<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Delete<TEntity>(TEntity entityId) where TEntity : class, IEntityBase;
    }
}
