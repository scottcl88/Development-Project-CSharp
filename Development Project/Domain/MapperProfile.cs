using Application.Models;
using AutoMapper;
using Infrastructure.Entities;

namespace Domain;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductModel, ProductEntity>().ReverseMap();        
    }
}
