using GeekShopping.ProductAPI.Data.Dtos;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    /// <summary>
    /// Controlador de produtos
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        //----------------------------------------//
        //          Variáveis membro              //
        //----------------------------------------//
        /// <summary>
        /// Repositório
        /// </summary>
        private IProductRepository _repository;

        //----------------------------------------//
        //          Construtor                    //
        //----------------------------------------//
        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="repository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Obtém um produto específico do banco de dados
        /// </summary>
        /// <returns>IEnumerable ProductDto</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        /// <summary>
        /// Obtém um produto específico do banco de dados
        /// </summary>
        /// <param name="id">Id do produto a ser pesquisado no banco de dados</param>
        /// <returns>ProductDto</returns>
        /// <response code="200">Caso exista o produto no banco de dados</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Criar um produto no banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para criação do produto</param>
        /// <returns>ProductDto</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _repository.Create(productDto);
            return Ok(product);
        }

        /// <summary>
        /// Atualiza um produto no banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para atualização do produto</param>
        /// <returns>ProductDto</returns>
        /// <response code="201">Caso a atualização seja feita com sucesso</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _repository.Update(productDto);
            return Ok(product);
        }

        /// <summary>
        /// Remove um determinado produto do banco de dados
        /// </summary>
        /// <param name="id">Id do produto a ser pesquisado no banco de dados</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Caso ocorra a remoção do item</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();

            return Ok(status);

        }
    }
}
