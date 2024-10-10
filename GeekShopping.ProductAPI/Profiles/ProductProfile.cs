using AutoMapper;
using GeekShopping.ProductAPI.Data.Dtos;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Profiles
{
    /// <summary>
    /// Mapeamento do produto
    /// </summary>
    public class ProductProfile : Profile
    {
        //----------------------------------------//
        //          Construtor                    //
        //----------------------------------------//
        /// <summary>
        /// Contrutor padrão
        /// </summary>
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
