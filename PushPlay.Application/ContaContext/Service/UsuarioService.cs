using AutoMapper;
using PushPlay.Application.ContaContext.Dto;
using PushPlay.CrossCutting.Exceptions;
using PushPlay.Data.AzureBlobStorageHelper;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Application.ContaContext.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IAzureBlobStorage _storage;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IAzureBlobStorage storage)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _storage = storage;
        }

        public async Task<UsuarioOutputDto> Create(UsuarioInputDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            usuario.Validate();

            await TrateFoto(usuario);

            await _usuarioRepository.Save(usuario);

            return _mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> GetAll()
        {
            IEnumerable<Usuario> result = await _usuarioRepository.GetAll();

            return _mapper.Map<List<UsuarioOutputDto>>(result);
        }

        public async Task<UsuarioOutputDto> GetById(Guid id)
        {
            Usuario? entity = await _usuarioRepository.Get(id);
            return entity == null ? throw new IdNotFoundException(nameof(Usuario)) : _mapper.Map<UsuarioOutputDto>(entity);
        }

        public async Task<UsuarioOutputDto> Update(Guid id, UsuarioInputDto dto)
        {
            Usuario? entity = await _usuarioRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Usuario));

            entity = _mapper.Map(dto, entity);

            entity.Validate();

            await TrateFoto(entity);

            await _usuarioRepository.Update(entity);

            return _mapper.Map<UsuarioOutputDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            Usuario? entity = await _usuarioRepository.Get(id);
            if (entity == null)
                throw new IdNotFoundException(nameof(Usuario));

            await _usuarioRepository.Delete(entity);

            return true;
        }

        public async Task<bool> Autentique(string email, string senha)
        {
            return await _usuarioRepository.Autentique(email, senha);
        }

        private async Task TrateFoto(Usuario usuario)
        {
            HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync(usuario.LinkFoto);

            if (response.IsSuccessStatusCode)
            {
                using Stream stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await _storage.UploadFile(fileName, "imagens", stream);

                usuario.LinkFoto = pathStorage;
            }
        }
    }
}