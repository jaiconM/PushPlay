using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class DeleteArtistaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteArtistaCommand(Guid id)
        {
            Id = id;
        }
    }
}
