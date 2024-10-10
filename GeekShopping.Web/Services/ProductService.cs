using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Reflection;

namespace GeekShopping.Web.Services
{
    /// <summary>
    /// Classe de serviços do Produto
    /// </summary>
    public class ProductService : IProductService
    {
        //----------------------------------------//
        //          Variáveis membro              //
        //----------------------------------------//
        /// <summary>
        /// HTTP Client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Caminho base
        /// </summary>
        public const string BasePath = "api/v1/product";

        //----------------------------------------//
        //            Contrutor                   //
        //----------------------------------------//
        /// <summary>
        /// Contrutor padrão
        /// </summary>
        /// <param name="httpClient"></param>
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtém todos os produtos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        /// <summary>
        /// Obtém um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();

            throw new Exception("Ocorreu algo de errado ao chamar a API de produtos para criação.");
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();

            throw new Exception("Ocorreu algo de errado ao chamar a API de produtos para atualização.");
        }

        /// <summary>
        /// Remove um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Ocorreu algo de errado ao chamar a API de produtos para remoção.");
        }
    }
}
