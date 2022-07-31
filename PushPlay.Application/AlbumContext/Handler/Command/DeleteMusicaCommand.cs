using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class DeleteMusicaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteMusicaCommand(Guid id)
        {
            Id = id;
        }
    }
}
