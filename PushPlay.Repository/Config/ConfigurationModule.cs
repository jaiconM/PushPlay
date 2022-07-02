using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PushPlay.Domain.AlbumContext.Repository;
using PushPlay.Domain.ContaContext.Repository;
using PushPlay.Repository.Contexto;
using PushPlay.Repository.Database;

namespace PushPlay.Repository.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PushPlayContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IEstiloMusicalRepository, EstiloMusicalRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IPlayListRepository, PlayListRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
