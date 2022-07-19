// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using TodoListManager.Data;
using TodoListManager.Data.Models;

namespace TodoListManager.Web.Models.Generic_Repo
{
   public interface IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> PrepareQuery();
        TEntity Find(int id);

        void Add(TEntity entity);
        void Delete(TEntity entity);
        int Save();
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : EntityBase
    {
        private readonly TodoListContext _dbContext;
        protected DbSet<TEntity> dbSet { get; init; }

        public GenericRepository(TodoListContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> PrepareQuery() =>
            dbSet.AsQueryable();

        public TEntity Find(int id)
            => PrepareQuery().SingleOrDefault(x => x.Id == id);

        public void Add(TEntity entity) =>
            dbSet.Add(entity);

        public void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
             dbSet.Remove(entity);

        }

        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }


        public int Save()
            => _dbContext.SaveChanges();
    }
}
