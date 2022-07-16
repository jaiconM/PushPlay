using PushPlay.Application.AlbumContext.Dto;
using System.ComponentModel.DataAnnotations;

namespace PushPlay.Application.ContaContext.Dto
{
    public record UsuarioInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome,
        [Required(ErrorMessage = "E-mail é obrigatório")]
        string Email,
        [Required(ErrorMessage = "Senha é obrigatória")]
        string Senha,
        string? LinkFoto,
        List<PlayListInputDto>? PlayLists,
        List<PlayListInputDto>? PlayListsQueSegue
    );

    public record UsuarioOutputDto(
        Guid Id,
        string Nome,
        string Email,
        string Senha,
        string LinkFoto,
        List<PlayListOutputDto> PlayLists,
        List<PlayListOutputDto> PlayListsQueSegue
    );

    public record PlayListInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome,
        List<MusicaInputDto>? Musicas
    );

    public record PlayListOutputDto(
        Guid Id,
        string Nome,
        List<MusicaOutputDto> Musicas
    );
}