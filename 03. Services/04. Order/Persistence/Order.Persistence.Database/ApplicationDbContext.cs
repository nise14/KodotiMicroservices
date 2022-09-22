using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Persistence.Database.Configuration;

namespace Order.Persistence.Database;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Order");
        ModelConfig(builder);
    }

    public DbSet<Domain.Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }

    private void ModelConfig(ModelBuilder builder)
    {
        new OrderConfiguation(builder.Entity<Domain.Order>());
        new OrderDetailConfiguration(builder.Entity<OrderDetail>());
    }
}
