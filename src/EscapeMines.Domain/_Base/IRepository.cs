using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Domain._Base
{
    public interface IRepository<TEntity>
    {
        TEntity searchById(int id);
        List<TEntity> search();
        void Add(TEntity entity);
    }
}
