using GeekShopping.Web.Models;
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

        /// <summary>
        /// Index Produto
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        /// <summary>
        /// Reideriza a tela de criação
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ProductCreate()
        {
            return View();
        }

        /// <summary>
        /// Realiza a criação do produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response != null) 
                    return RedirectToAction(nameof(ProductIndex));
            }
            
            return View(model);
        }

        /// <summary>
        /// Reinderiza a tela de atualização
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ProductUpdate(int id)
        {
            var product = await _productService.FindProductById(id);

            if (product != null)
                return View(product);

            return NotFound();
        }

        /// <summary>
        /// Atualização do produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        /// <summary>
        /// Reinderiza a tela de remoção de produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ProductDelete(int id)
        {
            var product = await _productService.FindProductById(id);

            if (product != null)
                return View(product);

            return NotFound();
        }

        /// <summary>
        /// Realiza a remoção do produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ProductDelete(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductById(model.Id);
                if (response)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View();
        }
    }
}
