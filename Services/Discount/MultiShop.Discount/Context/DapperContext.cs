using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=LAPTOP-7FU59OPV;Database=myDataBase;Uid=sa;Pwd=10081991;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-SLLU6PK; initial Catalog=MultiShopDiscountDb; integrated Security=true");
        }

        public DbSet<Coupon> Coupons{ get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
