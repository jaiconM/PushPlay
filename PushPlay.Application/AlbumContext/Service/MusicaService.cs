using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IMapper _mapper;

        public MusicaService(IMusicaRepository musicaRepository, IMapper mapper)
        {
            _musicaRepository = musicaRepository;
            _mapper = mapper;
        }

        public async Task<MusicaOutputDto> Create(MusicaInputDto dto)
        {
            var musica = _mapper.Map<Musica>(dto);

            await _musicaRepository.Save(musica);

            return _mapper.Map<MusicaOutputDto>(musica);
        }

        public async Task<List<MusicaOutputDto>> GetAll()
        {
            var result = await _musicaRepository.GetAllWithIncludes();

            return _mapper.Map<List<MusicaOutputDto>>(result);
        }
    }
}