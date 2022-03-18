using Microsoft.EntityFrameworkCore;
using Shop.Database.Entities;

namespace Shop.Databases;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; } = null!;

    //public DbSet<GameStateEntity> GameStates { get; set; } = null!;
    //public DbSet<PlayerEntity> Players { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}