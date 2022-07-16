using MediatR;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;
using PushPlay.Application.AlbumContext.Service;

namespace PushPlay.Application.ArtistaContext.Handler
{
    public class ArtistaHandler : IRequestHandler<CreateArtistaCommand, CreateArtistaCommandResponse>,
                                IRequestHandler<GetAllArtistaQuery, GetAllArtistaQueryResponse>
    {
        private readonly IArtistaService _artistaService;

        public ArtistaHandler(IArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        public async Task<CreateArtistaCommandResponse> Handle(CreateArtistaCommand request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.Create(request.Artista);
            return new CreateArtistaCommandResponse(result);
        }

        public async Task<GetAllArtistaQueryResponse> Handle(GetAllArtistaQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistaService.GetAll();
            return new GetAllArtistaQueryResponse(result);
        }
    }
}
