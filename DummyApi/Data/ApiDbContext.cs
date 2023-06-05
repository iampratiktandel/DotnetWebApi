using DummyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyApi.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext()
    {

    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LP149;Database=DevDB;User Id=sa;Password=Admin@123;");
    }
}
