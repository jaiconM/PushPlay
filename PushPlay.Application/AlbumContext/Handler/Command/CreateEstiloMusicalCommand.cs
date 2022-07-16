using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateEstiloMusicalCommand : IRequest<CreateEstiloMusicalCommandResponse>
    {
        public EstiloMusicalInputDto EstiloMusical { get; set; }

        public CreateEstiloMusicalCommand(EstiloMusicalInputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
