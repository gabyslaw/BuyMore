using AutoMapper;
using BuyMore.Services.ProductAPI.Models;
using BuyMore.Services.ProductAPI.Models.Dtos;

namespace BuyMore.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
               // config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
