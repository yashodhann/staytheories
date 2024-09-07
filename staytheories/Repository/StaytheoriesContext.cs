using Microsoft.EntityFrameworkCore;
using staytheories.Model;

namespace staytheories.Repository;

public class StaytheoriesContext : DbContext
{
    static readonly string ConnectionString = "Server=localhost; User ID=root; Password=12345678; Database=staytheories;";

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductSale> ProductSales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    }
}