using Microsoft.EntityFrameworkCore;
using OrderAPI.Models.Entities;

namespace OrderAPI.Models;

public class OrderAPIDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    public OrderAPIDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(o =>
        {
            o.ToTable("Orders").HasKey("Id");
            o.Property(o => o.UserId).HasColumnName("UserId");
            o.Property(o => o.Id).HasColumnName("Id");
            o.HasMany(o => o.Products).WithOne(p => p.Order).HasForeignKey(p => p.OrderId);
        });
        modelBuilder.Entity<Product>(p =>
        {
            p.ToTable("Products").HasKey("Id");
            p.Property(p=>p.Name).HasColumnName("Name");
            p.Property(p=>p.Id).HasColumnName("Id");

        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entities = ChangeTracker.Entries();
        foreach (var entityEntry in entities)
        {
            if (entityEntry.Entity is BaseEntity entity)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDate = DateTime.UtcNow;
                entity.UpdatedDate = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}