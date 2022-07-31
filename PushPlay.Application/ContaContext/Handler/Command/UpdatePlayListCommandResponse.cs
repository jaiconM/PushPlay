using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class UpdatePlayListCommandResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public UpdatePlayListCommandResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
