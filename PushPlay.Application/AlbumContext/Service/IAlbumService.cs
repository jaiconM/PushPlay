using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Create(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> GetAll();
    }
}