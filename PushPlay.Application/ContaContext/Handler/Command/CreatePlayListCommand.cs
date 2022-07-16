using MediatR;
using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class CreatePlayListCommand : IRequest<CreatePlayListCommandResponse>
    {
        public PlayListInputDto PlayList { get; set; }

        public CreatePlayListCommand(PlayListInputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
