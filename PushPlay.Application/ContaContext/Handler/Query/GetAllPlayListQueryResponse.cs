using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Query
{
    public class GetAllPlayListQueryResponse
    {
        public IList<PlayListOutputDto> PlayLists { get; set; }

        public GetAllPlayListQueryResponse(IList<PlayListOutputDto> playLists)
        {
            PlayLists = playLists;
        }
    }
}
