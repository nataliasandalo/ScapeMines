using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeMines.Data.Context;
using EscapeMines.Domain._Base;

namespace EscapeMines.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public TEntity searchById(int id)
        {
            var query = Context.Set<TEntity>().Where(e => e.Id == id);
            return query.Any() ? query.First() : null;
        }

        public List<TEntity> search()
        {
            var entity = Context.Set<TEntity>().ToList();
            return entity.Any() ? entity : new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
    }
}
