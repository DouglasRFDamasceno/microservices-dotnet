using AutoMapper;
using GeekShopping.ProductAPI.Data.Dtos;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    /// <summary>
    /// Repositório dos produtos
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        //----------------------------------------//
        //          Variáveis membro              //
        //----------------------------------------//
        /// <summary>
        /// MySQL context
        /// </summary>
        private readonly MySQLContext _context;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        //----------------------------------------//
        //          Contruturo                    //
        //----------------------------------------//
        /// <summary>
        /// Contruturo padrão
        /// </summary>
        /// <param name="context">MySQL context</param>
        /// <param name="mapper"></param>
        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //----------------------------------------//
        //          Métodos públicos              //
        //----------------------------------------//
        /// <summary>
        /// Obtém um produto específico do banco de dados
        /// </summary>
        /// <returns>IEnumerable ProductDto</returns>
        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            var dtos = _mapper.Map<List<ProductDto>>(products);
            Console.Write(dtos);
            return dtos;
        }

        /// <summary>
        /// Obtém um produto específico do banco de dados
        /// </summary>
        /// <param name="id">Id do produto a ser pesquisado no banco de dados</param>
        /// <returns>ProductDto</returns>
        public async Task<ProductDto> FindById(long id)
        {
            Product? product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Criar um produto no banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para criação do produto</param>
        /// <returns>ProductDto</returns>
        public async Task<ProductDto> Create(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Atualiza um produto no banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para atualização do produto</param>
        /// <returns>ProductDto</returns>
        public async Task<ProductDto> Update(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Remove um determinado produto do banco de dados
        /// </summary>
        /// <param name="id">Id do produto a ser pesquisado no banco de dados</param>
        /// <returns>ActionResult</returns>
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product? product = await _context.Products.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
