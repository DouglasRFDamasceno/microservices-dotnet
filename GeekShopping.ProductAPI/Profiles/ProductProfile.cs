using AutoMapper;
using GeekShopping.ProductAPI.Data.Dtos;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
