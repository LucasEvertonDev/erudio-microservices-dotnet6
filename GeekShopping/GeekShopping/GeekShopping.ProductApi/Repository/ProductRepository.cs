using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _mySqlContext;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlContext mySqlContext,
            IMapper mapper)
        {
            _mySqlContext = mySqlContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _mySqlContext.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(int id)
        {
            Product product = await _mySqlContext.Products.Where(p => p.Id == id).FirstAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _mySqlContext.Products.Add(product);
            await _mySqlContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _mySqlContext.Products.Update(product);
            await _mySqlContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _mySqlContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                _mySqlContext.Remove(product);
                await _mySqlContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
