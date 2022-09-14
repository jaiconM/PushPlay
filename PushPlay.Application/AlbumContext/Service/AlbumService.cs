using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.CrossCutting.Exceptions;
using PushPlay.Data.AzureBlobStorageHelper;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorage _storage;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IAzureBlobStorage storage)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _storage = storage;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            Album album = _mapper.Map<Album>(dto);

            await TrateFoto(album);

            await _albumRepository.Save(album);

            return _mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            IEnumerable<Album> result = await _albumRepository.GetAllWithIncludes();

            return _mapper.Map<List<AlbumOutputDto>>(result);
        }

        public async Task<AlbumOutputDto> GetById(Guid id)
        {
            Album? entity = await _albumRepository.Get(id);
            return entity == null ? throw new IdNotFoundException(nameof(Album)) : _mapper.Map<AlbumOutputDto>(entity);
        }

        public async Task<AlbumOutputDto> Update(Guid id, AlbumInputDto dto)
        {
            Album? entity = await _albumRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Album));

            entity = _mapper.Map(dto, entity);

            await TrateFoto(entity);

            await _albumRepository.Update(entity);

            return _mapper.Map<AlbumOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            Album? entity = await _albumRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Album));

            await _albumRepository.Delete(entity);

            return true;
        }

        private async Task TrateFoto(Album album)
        {
            HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync(album.LinkFoto);

            if (response.IsSuccessStatusCode)
            {
                using Stream stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await _storage.UploadFile(fileName, "imagens", stream);

                album.LinkFoto = pathStorage;
            }
        }
    }
}