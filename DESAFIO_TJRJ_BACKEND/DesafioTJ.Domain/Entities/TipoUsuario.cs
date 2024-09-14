using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioTJ.Domain.Entities.Base;

namespace DesafioTJ.Domain.Entities
{
    public class TipoUsuario: BaseEntity
    {
        public string Origem { get; set; }
        public string Descricao { get; set; }
    }
}
