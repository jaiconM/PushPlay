using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateEstiloMusicalCommand : IRequest<UpdateEstiloMusicalCommandResponse>
    {
        public Guid Id { get; set; }
        public EstiloMusicalInputDto EstiloMusical { get; set; }

        public UpdateEstiloMusicalCommand(Guid id, EstiloMusicalInputDto estiloMusical)
        {
            Id = id;
            EstiloMusical = estiloMusical;
        }
    }
}
