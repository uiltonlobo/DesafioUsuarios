using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.ViewModel
{
    public class UsuarioViewModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public int? IdTipoUsuario { get; set; }
        public TipoUsuarioViewModel? TipoUsuario { get; set; }
    }
}
