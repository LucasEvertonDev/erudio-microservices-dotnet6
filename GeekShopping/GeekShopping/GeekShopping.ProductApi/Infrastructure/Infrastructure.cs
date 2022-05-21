using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.MappingProfile;
using GeekShopping.ProductApi.Model.Context;
using GeekShopping.ProductApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Infrastructure
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
               new MySqlServerVersion (new Version(8, 0, 29))));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityToVOMappingProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
