using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Infra.Database;
using DesafioTJ.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Infra.Repository
{
    public class TipoUsuarioRepository : BaseRepository<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(UsuarioContext context) : base(context) { }
    }
}
