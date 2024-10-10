using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    /// <summary>
    /// Interface Serviço produto
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtém todos os produtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductModel>> FindAllProducts();

        /// <summary>
        /// Encontrar um produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductModel> FindProductById(long id);

        /// <summary>
        /// Criar um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductModel> CreateProduct(ProductModel model);

        /// <summary>
        /// Atualizar um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductModel> UpdateProduct(ProductModel model);

        /// <summary>
        /// Remover um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteProductById(long id);
    }
}
