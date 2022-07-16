using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Service
{
    public interface IMusicaService
    {
        Task<MusicaOutputDto> Create(MusicaInputDto dto);
        Task<List<MusicaOutputDto>> GetAll();
    }
}