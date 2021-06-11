using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TAP.DataAccess.Repositories;
using TAP.Core.Entities;
using TAP.Core;

namespace TAP.DataAccess.SqlServer.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly TAPContext dataContext;

        public DataRepository(TAPContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase
        {
            return dataContext.Set<TEntity>();
        }

        void IDataRepository.Delete<TEntity>(TEntity item)
        {
            var entity = dataContext.Set<TEntity>()
                .SingleOrDefault(e => e.Id == item.Id);
            if (item != null)
            {
                dataContext.Remove(entity);
            }
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            dataContext.Add(entity);
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            dataContext.Update(entity);
        }
    }
}
