using AutoMapper;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Domain.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Usuario,UsuarioViewModel>().ReverseMap();

            CreateMap<TipoUsuario, TipoUsuarioViewModel>().ReverseMap();

            CreateMap<UsuarioSP, UsuarioViewModel>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => 
                    new TipoUsuarioViewModel
                    {
                        Id = src.IdTipoUsuario,
                        Origem = src.Origem,
                        Descricao = src.Descricao
                    }
                ));
        }
    }
}
