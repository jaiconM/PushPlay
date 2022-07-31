using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateMusicaCommandResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public UpdateMusicaCommandResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
