using MediatR;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;
using PushPlay.Application.AlbumContext.Service;

namespace PushPlay.Application.MusicaContext.Handler
{
    public class MusicaHandler : IRequestHandler<CreateMusicaCommand, CreateMusicaCommandResponse>,
                                IRequestHandler<GetAllMusicaQuery, GetAllMusicaQueryResponse>
    {
        private readonly IMusicaService _musicaService;

        public MusicaHandler(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<CreateMusicaCommandResponse> Handle(CreateMusicaCommand request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.Create(request.Musica);
            return new CreateMusicaCommandResponse(result);
        }

        public async Task<GetAllMusicaQueryResponse> Handle(GetAllMusicaQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicaService.GetAll();
            return new GetAllMusicaQueryResponse(result);
        }
    }
}
