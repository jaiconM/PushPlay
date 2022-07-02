using PushPlay.Application.Album.Dto;
using PushPlay.Domain.AlbumContext;

namespace PushPlay.Application.Album.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(dto => dto.Duracao, mapper => mapper.MapFrom(musica => musica.Duracao.ValorFormatado));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(musica => musica.Duracao.Valor, mapper => mapper.MapFrom(dto => dto.Duracao));

            CreateMap<Domain.AlbumContext.Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, Domain.AlbumContext.Album>();
        }
    }
}
