using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Service
{
    public interface IEstiloMusicalService
    {
        Task<EstiloMusicalOutputDto> Create(EstiloMusicalInputDto dto);
        Task<List<EstiloMusicalOutputDto>> GetAll();
    }
}