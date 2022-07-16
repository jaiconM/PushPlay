using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class CreatePlayListCommandResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public CreatePlayListCommandResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
