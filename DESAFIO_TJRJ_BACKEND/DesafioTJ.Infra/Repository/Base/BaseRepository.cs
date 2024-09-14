using DesafioTJ.Domain.Entities.Base;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Infra.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly UsuarioContext _usuarioContext;

        public BaseRepository(UsuarioContext context)
        {
            _usuarioContext = context;
        }

        public void SaveChanges()
        {
            _usuarioContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _usuarioContext.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return _usuarioContext.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            _usuarioContext.Add(entity);
        }
    }
}
