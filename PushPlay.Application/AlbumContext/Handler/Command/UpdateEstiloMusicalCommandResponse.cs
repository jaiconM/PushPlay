using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateEstiloMusicalCommandResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public UpdateEstiloMusicalCommandResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
