using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;

namespace GeekShopping.ProductApi.MappingProfile
{
    public class EntityToVOMappingProfile : Profile
    {
        public EntityToVOMappingProfile()
        {
            CreateMap<ProductVO, Product>().ReverseMap();
        }
    }
}
