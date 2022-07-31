using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Query
{
    public class GetByIdPlayListQueryResponse
    {
        public PlayListOutputDto PlayList { get; set; }

        public GetByIdPlayListQueryResponse(PlayListOutputDto playlist)
        {
            PlayList = playlist;
        }
    }
}
