using GeekShopping.ProductAPI.Data.Dtos;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<IEnumerable<ProductDto>> FindById(long id);
        Task<IEnumerable<ProductDto>> Create(ProductDto productDto);
        Task<IEnumerable<ProductDto>> Update(ProductDto productDto);
        Task<bool> Delete(long id);
    }
}
