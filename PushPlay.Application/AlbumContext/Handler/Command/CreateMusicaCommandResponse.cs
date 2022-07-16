using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateMusicaCommandResponse
    {
        public MusicaOutputDto Musica { get; set; }

        public CreateMusicaCommandResponse(MusicaOutputDto musica)
        {
            Musica = musica;
        }
    }
}
