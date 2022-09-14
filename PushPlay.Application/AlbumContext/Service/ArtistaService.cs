using AutoMapper;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.CrossCutting.Exceptions;
using PushPlay.Data.AzureBlobStorageHelper;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Application.AlbumContext.Service
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorage _storage;

        public ArtistaService(IArtistaRepository artistaRepository, IMapper mapper, IAzureBlobStorage storage)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
            _storage = storage;
        }

        public async Task<ArtistaOutputDto> Create(ArtistaInputDto dto)
        {
            Artista artista = _mapper.Map<Artista>(dto);

            await TrateFoto(artista);

            await _artistaRepository.Save(artista);

            return _mapper.Map<ArtistaOutputDto>(artista);
        }

        public async Task<List<ArtistaOutputDto>> GetAll()
        {
            IEnumerable<Artista> result = await _artistaRepository.GetAll();

            return _mapper.Map<List<ArtistaOutputDto>>(result);
        }

        public async Task<ArtistaOutputDto> GetById(Guid id)
        {
            Artista? entity = await _artistaRepository.Get(id);
            return entity == null ? throw new IdNotFoundException(nameof(Artista)) : _mapper.Map<ArtistaOutputDto>(entity);
        }

        public async Task<ArtistaOutputDto> Update(Guid id, ArtistaInputDto dto)
        {
            Artista? entity = await _artistaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Artista));

            entity = _mapper.Map(dto, entity);

            await TrateFoto(entity);

            await _artistaRepository.Update(entity);

            return _mapper.Map<ArtistaOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            Artista? entity = await _artistaRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Artista));

            await _artistaRepository.Delete(entity);

            return true;
        }

        private async Task TrateFoto(Artista artista)
        {
            HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync(artista.LinkFoto);

            if (response.IsSuccessStatusCode)
            {
                using Stream stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await _storage.UploadFile(fileName, "imagens", stream);

                artista.LinkFoto = pathStorage;
            }
        }
    }
}