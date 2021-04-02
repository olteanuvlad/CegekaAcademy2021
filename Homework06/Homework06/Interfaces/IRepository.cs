using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Interfaces
{
    interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
