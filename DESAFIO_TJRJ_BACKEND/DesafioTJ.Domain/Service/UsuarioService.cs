using AutoMapper;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Entities.Validation;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Domain.Interfaces.Service;
using DesafioTJ.Domain.Resource;
using DesafioTJ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) 
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void IncluirUsuario(UsuarioViewModel usuarioVM)
        {
            usuarioVM.TipoUsuario = null;

            Usuario usuario = _mapper.Map<Usuario>(usuarioVM);
            
            ValidarUsuario(usuario);

            VerificarDuplicidades(usuario);

            _usuarioRepository.Add(usuario);

            _usuarioRepository.SaveChanges();
        }        

        public IList<UsuarioViewModel> ListarUsuarios()
        {
            IList<Usuario> usuarios = _usuarioRepository.GetAll();

            IList<UsuarioViewModel> usuariosVM = _mapper.Map<IList<UsuarioViewModel>>(usuarios);

            return usuariosVM;
        }

        public UsuarioViewModel ObterUsuarioPorId(int id)
        {
            Usuario usuario = _usuarioRepository.Get(id);

            return usuario != null ? _mapper.Map<UsuarioViewModel>(usuario) : null;
        }

        public IList<UsuarioViewModel> ListarUsuariosPorOrigem(string origem)
        {
            IList<UsuarioSP> usuarios = _usuarioRepository.GetUsuariosPorOrigem(origem);

            IList<UsuarioViewModel> usuariosVM = _mapper.Map<List<UsuarioViewModel>>(usuarios);

            return usuariosVM;
        }


        private void VerificarDuplicidades(Usuario usuario)
        {
            bool matriculaExistente = _usuarioRepository.Any(x => x.Matricula.Equals(usuario.Matricula, StringComparison.InvariantCultureIgnoreCase));

            bool emailExistente = _usuarioRepository.Any(x => x.Email.Equals(usuario.Email, StringComparison.InvariantCultureIgnoreCase));

            StringBuilder sb = new StringBuilder();

            if (matriculaExistente) sb.Append($" | " + string.Format(ResourceMessages.CAMPO_UTILIZADO_POR_OUTRO_REGISTRO, "Matrícula", "Usuário"));

            if (emailExistente) sb.Append($" | " + string.Format(ResourceMessages.CAMPO_UTILIZADO_POR_OUTRO_REGISTRO, "Email", "Usuário"));

            if (matriculaExistente || emailExistente)
                throw new Exception(sb.ToString());
        }

        private static void ValidarUsuario(Usuario usuario)
        {
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            if (result.Errors.Any())
            {
                StringBuilder erros = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    erros.Append($" | {error.ErrorMessage}");
                }

                throw new Exception(erros.ToString());
            }
        }

    }
}
