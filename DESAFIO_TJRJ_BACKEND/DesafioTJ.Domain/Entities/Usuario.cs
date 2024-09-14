using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioTJ.Domain.Entities.Base;

namespace DesafioTJ.Domain.Entities
{
    public class Usuario: BaseEntity
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public int IdTipoUsuario { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }
        
    }
}
