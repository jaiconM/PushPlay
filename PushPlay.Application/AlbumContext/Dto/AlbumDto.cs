
namespace PushPlay.Application.Album.Dto
{
    public record AlbumInputDto(string Nome, string Descricao, string LinkFoto, int Ano, List<MusicaInputDto> Musicas);
    public record AlbumOutputDto(Guid Id, string Nome, string Descricao, string LinkFoto, int Ano, List<MusicaOutputDto> Musicas);
    public record MusicaInputDto(string Nome, int Duracao, Guid EstiloMusicalId);
    public record MusicaOutputDto(Guid Id, string Nome, string Duracao);
}