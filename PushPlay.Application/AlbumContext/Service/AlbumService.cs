using AutoMapper;
using PushPlay.Application.Album.Dto;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = _mapper.Map<Domain.AlbumContext.Album>(dto);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> ObterTodos()
        {
            var result = await _albumRepository.GetAll();

            return _mapper.Map<List<AlbumOutputDto>>(result);
        }
    }
}