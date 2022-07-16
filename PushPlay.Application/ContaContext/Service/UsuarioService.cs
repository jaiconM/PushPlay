using AutoMapper;
using PushPlay.Application.ContaContext.Dto;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Application.ContaContext.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Create(UsuarioInputDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            await _usuarioRepository.Save(usuario);

            return _mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> GetAll()
        {
            var result = await _usuarioRepository.GetAll();

            return _mapper.Map<List<UsuarioOutputDto>>(result);
        }
    }
}