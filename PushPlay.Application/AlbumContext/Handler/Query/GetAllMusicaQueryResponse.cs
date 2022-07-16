using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetAllMusicaQueryResponse
    {
        public IList<MusicaOutputDto> Musicas { get; set; }

        public GetAllMusicaQueryResponse(IList<MusicaOutputDto> musicas)
        {
            Musicas = musicas;
        }
    }
}
