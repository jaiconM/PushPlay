using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Service
{
    public interface IArtistaService
    {
        Task<ArtistaOutputDto> Create(ArtistaInputDto dto);
        Task<List<ArtistaOutputDto>> GetAll();
    }
}