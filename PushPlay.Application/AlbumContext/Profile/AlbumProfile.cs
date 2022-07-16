using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Domain.AlbumContext;

namespace PushPlay.Application.AlbumContext.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<EstiloMusical, EstiloMusicalOutputDto>();

            CreateMap<EstiloMusicalInputDto, EstiloMusical>();

            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(dto => dto.Duracao, mapper => mapper.MapFrom(musica => musica.Duracao.ValorFormatado));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(musica => musica.Duracao.Valor, mapper => mapper.MapFrom(dto => dto.Duracao));

            CreateMap<Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, Album>();

            CreateMap<Artista, ArtistaOutputDto>();

            CreateMap<ArtistaInputDto, Artista>();
        }
    }
}
