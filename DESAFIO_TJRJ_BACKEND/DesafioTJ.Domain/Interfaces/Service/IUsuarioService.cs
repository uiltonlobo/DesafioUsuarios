using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        IList<UsuarioViewModel> ListarUsuarios();
        void IncluirUsuario(UsuarioViewModel usuarioVM);
        UsuarioViewModel ObterUsuarioPorId(int id);
        IList<UsuarioViewModel> ListarUsuariosPorOrigem(string origem);
    }
}
