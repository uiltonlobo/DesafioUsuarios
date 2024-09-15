using DesafioTJ.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void SaveChanges();
        bool Any(Func<TEntity, bool> predicate);
    }
}
