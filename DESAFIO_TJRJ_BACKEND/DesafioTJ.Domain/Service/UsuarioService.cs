using AutoMapper;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Entities.Validation;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Domain.Interfaces.Service;
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
            Usuario usuario = _mapper.Map<Usuario>(usuarioVM);
            
            ValidarUsuario(usuario);

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
