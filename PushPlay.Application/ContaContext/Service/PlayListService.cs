using AutoMapper;
using PushPlay.Application.ContaContext.Dto;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Application.ContaContext.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlayListService(IPlayListRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<PlayListOutputDto> Create(PlayListInputDto dto)
        {
            var playlist = _mapper.Map<PlayList>(dto);

            await _playlistRepository.Save(playlist);

            return _mapper.Map<PlayListOutputDto>(playlist);
        }

        public async Task<List<PlayListOutputDto>> GetAll()
        {
            var result = await _playlistRepository.GetAll();

            return _mapper.Map<List<PlayListOutputDto>>(result);
        }
    }
}