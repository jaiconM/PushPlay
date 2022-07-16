using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
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
            var album = _mapper.Map<Album>(dto);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            var result = await _albumRepository.GetAll();

            return _mapper.Map<List<AlbumOutputDto>>(result);
        }
    }
}