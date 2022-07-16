using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateEstiloMusicalCommandResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public CreateEstiloMusicalCommandResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
