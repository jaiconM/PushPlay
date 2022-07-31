using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdMusicaQueryResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public GetByIdMusicaQueryResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
