using PushPlay.Application.ContaContext.Dto;
using PushPlay.Domain.ContaContext;

namespace PushPlay.Application.ContaContext.Profile
{
    public class ContaProfile : AutoMapper.Profile
    {
        public ContaProfile()
        {
            CreateMap<Usuario, UsuarioOutputDto>()
                .ForMember(dto => dto.Email, mapper => mapper.MapFrom(musica => musica.Email.Valor))
                .ForMember(dto => dto.Senha, mapper => mapper.MapFrom(musica => musica.Senha.Valor));

            CreateMap<UsuarioInputDto, Usuario>()
                .ForPath(musica => musica.Email.Valor, mapper => mapper.MapFrom(dto => dto.Email))
                .ForPath(musica => musica.Senha.Valor, mapper => mapper.MapFrom(dto => dto.Senha));

            CreateMap<PlayList, PlayListOutputDto>();

            CreateMap<PlayListInputDto, PlayList>();
        }
    }
}
