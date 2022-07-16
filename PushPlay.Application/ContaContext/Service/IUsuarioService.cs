using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Create(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> GetAll();
    }
}