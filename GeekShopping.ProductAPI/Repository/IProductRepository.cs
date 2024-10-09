using GeekShopping.ProductAPI.Data.Dtos;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(long id);
        Task<ProductDto> Create(ProductDto productDto);
        Task<ProductDto> Update(ProductDto productDto);
        Task<bool> Delete(long id);
    }
}
