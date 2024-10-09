using AutoMapper;
using GeekShopping.ProductAPI.Data.Dtos;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

/// <inheritdoc/>
        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            var dtos = _mapper.Map<List<ProductDto>>(products);
            Console.Write(dtos);
            return dtos;
        }

/// <inheritdoc/>
        public async Task<ProductDto> FindById(long id)
        {
            Product? product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

/// <inheritdoc/>
        public async Task<ProductDto> Create(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

/// <inheritdoc/>
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

/// <inheritdoc/>
        public async Task<ProductDto> Update(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
