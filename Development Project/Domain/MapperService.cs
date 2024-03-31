using Application.Models;
using AutoMapper;
using Infrastructure.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;
public static class MapperService
{
    public static IServiceCollection AddMapperServices(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}