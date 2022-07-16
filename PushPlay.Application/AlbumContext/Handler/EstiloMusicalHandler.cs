using MediatR;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;
using PushPlay.Application.AlbumContext.Service;

namespace PushPlay.Application.EstiloMusicalContext.Handler
{
    public class EstiloMusicalHandler : IRequestHandler<CreateEstiloMusicalCommand, CreateEstiloMusicalCommandResponse>,
                                IRequestHandler<GetAllEstiloMusicalQuery, GetAllEstiloMusicalQueryResponse>
    {
        private readonly IEstiloMusicalService _estiloMusicalService;

        public EstiloMusicalHandler(IEstiloMusicalService estiloMusicalService)
        {
            _estiloMusicalService = estiloMusicalService;
        }

        public async Task<CreateEstiloMusicalCommandResponse> Handle(CreateEstiloMusicalCommand request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.Create(request.EstiloMusical);
            return new CreateEstiloMusicalCommandResponse(result);
        }

        public async Task<GetAllEstiloMusicalQueryResponse> Handle(GetAllEstiloMusicalQuery request, CancellationToken cancellationToken)
        {
            var result = await _estiloMusicalService.GetAll();
            return new GetAllEstiloMusicalQueryResponse(result);
        }
    }
}
