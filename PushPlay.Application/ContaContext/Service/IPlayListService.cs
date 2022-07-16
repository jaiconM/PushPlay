using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Service
{
    public interface IPlayListService
    {
        Task<PlayListOutputDto> Create(PlayListInputDto dto);
        Task<List<PlayListOutputDto>> GetAll();
    }
}