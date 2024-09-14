using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Infra.Database;
using DesafioTJ.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context) : base(context)
        {
            _context = context;
        }

        public IList<UsuarioSP> GetUsuariosPorOrigem(string origem)
        {
            var usuarios = _context.UsuariosSP.FromSqlRaw($"call ListarUsuariosPorOrigem('{origem}');").ToList();

            return usuarios;
        }
    }
}
