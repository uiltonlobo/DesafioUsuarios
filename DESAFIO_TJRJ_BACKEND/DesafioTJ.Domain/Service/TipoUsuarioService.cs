using AutoMapper;
using DesafioTJ.Domain.Entities;
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
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository, IMapper mapper)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _mapper = mapper;
        }

        public IList<TipoUsuarioViewModel> ListarTiposUsuario()
        {
            IList<TipoUsuario> tiposUsuario = _tipoUsuarioRepository.GetAll();

            IList<TipoUsuarioViewModel> tiposUsuarioVM = _mapper.Map<IList<TipoUsuarioViewModel>>(tiposUsuario);

            return tiposUsuarioVM;
        }
    }
}
