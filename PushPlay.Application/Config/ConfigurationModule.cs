using Microsoft.Extensions.DependencyInjection;
using PushPlay.Application.Album.Service;

namespace PushPlay.Application.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            services.AddScoped<IAlbumService, AlbumService>();

            return services;
        }
    }
}
