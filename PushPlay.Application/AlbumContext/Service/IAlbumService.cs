using PushPlay.Application.Album.Dto;

namespace PushPlay.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Create(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> ObterTodos();
    }
}