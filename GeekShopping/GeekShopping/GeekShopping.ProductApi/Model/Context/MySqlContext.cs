using GeekShopping.ProductApi.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() {}
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetDataBuilder();
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(MySqlContext).Assembly);
        }
    }
}
