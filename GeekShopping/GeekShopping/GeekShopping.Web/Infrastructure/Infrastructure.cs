using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Infrastructure
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IProductService, ProductService>(
                c => c.BaseAddress = new Uri(configuration["ServiceUrls:ProductAPI"]));

            return services;
        }
    }
}
