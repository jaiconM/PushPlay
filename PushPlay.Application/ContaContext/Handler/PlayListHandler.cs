using MediatR;
using PushPlay.Application.ContaContext.Handler.Command;
using PushPlay.Application.ContaContext.Handler.Query;
using PushPlay.Application.ContaContext.Service;

namespace PushPlay.Application.ContaContext.Handler
{
    public class PlayListHandler : IRequestHandler<CreatePlayListCommand, CreatePlayListCommandResponse>,
                                IRequestHandler<GetAllPlayListQuery, GetAllPlayListQueryResponse>
    {
        private readonly IPlayListService _playListService;

        public PlayListHandler(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        public async Task<CreatePlayListCommandResponse> Handle(CreatePlayListCommand request, CancellationToken cancellationToken)
        {
            var result = await _playListService.Create(request.PlayList);
            return new CreatePlayListCommandResponse(result);
        }

        public async Task<GetAllPlayListQueryResponse> Handle(GetAllPlayListQuery request, CancellationToken cancellationToken)
        {
            var result = await _playListService.GetAll();
            return new GetAllPlayListQueryResponse(result);
        }
    }
}
