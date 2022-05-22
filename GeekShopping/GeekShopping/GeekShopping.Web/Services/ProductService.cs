using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(HttpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            var response = await _httpClient.PostAsJsonAsync(BasePath, productModel);
            if (response.IsSuccessStatusCode)
            { 
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
            var response = await _httpClient.PutAsJsonAsync(BasePath, productModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling API");
            }
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<bool>();
        }
    }
}
