using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
{
    public class EstiloMusicalService : IEstiloMusicalService
    {
        private readonly IEstiloMusicalRepository _estiloMusicalRepository;
        private readonly IMapper _mapper;

        public EstiloMusicalService(IEstiloMusicalRepository estiloMusicalRepository, IMapper mapper)
        {
            _estiloMusicalRepository = estiloMusicalRepository;
            _mapper = mapper;
        }

        public async Task<EstiloMusicalOutputDto> Create(EstiloMusicalInputDto dto)
        {
            var estiloMusical = _mapper.Map<EstiloMusical>(dto);

            await _estiloMusicalRepository.Save(estiloMusical);

            return _mapper.Map<EstiloMusicalOutputDto>(estiloMusical);
        }

        public async Task<List<EstiloMusicalOutputDto>> GetAll()
        {
            var result = await _estiloMusicalRepository.GetAll();

            return _mapper.Map<List<EstiloMusicalOutputDto>>(result);
        }
    }
}