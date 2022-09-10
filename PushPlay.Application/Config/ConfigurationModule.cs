﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PushPlay.Application.AlbumContext.Service;
using PushPlay.Application.ContaContext.Service;

namespace PushPlay.Application.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
            services.AddMediatR(typeof(ConfigurationModule).Assembly);

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistaService, ArtistaService>();
            services.AddScoped<IEstiloMusicalService, EstiloMusicalService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IPlayListService, PlayListService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAzureBlobStorage, AzureBlobStorage>();

            return services;
        }
    }
}
