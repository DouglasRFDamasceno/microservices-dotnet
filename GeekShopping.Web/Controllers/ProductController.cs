using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    /// <summary>
    /// Classe de controle do produto
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// Inteface do serviço do produto
        /// </summary>
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }


        public async Task<ActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
    }
}
