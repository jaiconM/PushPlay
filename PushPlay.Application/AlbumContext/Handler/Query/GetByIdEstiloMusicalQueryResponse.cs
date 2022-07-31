using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdEstiloMusicalQueryResponse
    {
        public EstiloMusicalOutputDto EstiloMusical { get; set; }

        public GetByIdEstiloMusicalQueryResponse(EstiloMusicalOutputDto estiloMusical)
        {
            EstiloMusical = estiloMusical;
        }
    }
}
