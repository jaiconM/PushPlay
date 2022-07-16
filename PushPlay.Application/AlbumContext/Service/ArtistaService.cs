using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public ArtistaService(IArtistaRepository artistaRepository, IMapper mapper)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        public async Task<ArtistaOutputDto> Create(ArtistaInputDto dto)
        {
            var artista = _mapper.Map<Artista>(dto);

            await _artistaRepository.Save(artista);

            return _mapper.Map<ArtistaOutputDto>(artista);
        }

        public async Task<List<ArtistaOutputDto>> GetAll()
        {
            var result = await _artistaRepository.GetAll();

            return _mapper.Map<List<ArtistaOutputDto>>(result);
        }
    }
}