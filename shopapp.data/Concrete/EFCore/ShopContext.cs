using Microsoft.EntityFrameworkCore;
using shopapp.entity;
namespace shopapp.data.Concrete.EFCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=loren.veridyen.com\\MSSQLSERVER2022;Database=heybeapp_;User Id=admin;Password=Mehmet44*,.;")
        }

    }
}