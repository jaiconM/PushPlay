using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Service
{
    public interface IArtistaService
    {
        Task<ArtistaOutputDto> Create(ArtistaInputDto dto);
        Task<List<ArtistaOutputDto>> GetAll();
        Task<ArtistaOutputDto> GetById(Guid id);
        Task<ArtistaOutputDto> Update(Guid id, ArtistaInputDto dto);
        Task<bool> Delete(Guid id);

    }
}