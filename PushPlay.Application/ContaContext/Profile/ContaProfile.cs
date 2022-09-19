using PushPlay.Application.ContaContext.Dto;
using PushPlay.Domain.ContaContext;

namespace PushPlay.Application.ContaContext.Profile
{
    public class ContaProfile : AutoMapper.Profile
    {
        public ContaProfile()
        {
            CreateMap<Usuario, UsuarioOutputDto>()
                .ForMember(dto => dto.Email, config => config.MapFrom(usuario => usuario.Email.Valor));

            CreateMap<UsuarioInputDto, Usuario>()
                .ForPath(usuario => usuario.Email.Valor, config => config.MapFrom(dto => dto.Email))
                .ForPath(usuario => usuario.Senha.Valor, config => config.MapFrom(dto => dto.Senha));

            CreateMap<PlayList, PlayListOutputDto>();

            CreateMap<PlayListInputDto, PlayList>();
        }
    }
}
