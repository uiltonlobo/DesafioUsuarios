using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.Interfaces.Service
{
    public interface ITipoUsuarioService
    {
        IList<TipoUsuarioViewModel> ListarTiposUsuario();
    }
}
