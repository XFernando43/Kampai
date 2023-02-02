using Kampai.Licors.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Kampai.Shared.Persistence.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Licor> Users { get; set; }
    
    public DbSet<Licor> licor { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Licor>().ToTable("Licors");
        builder.Entity<Licor>().HasKey(p => p.Id);
        builder.Entity<Licor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Licor>().Property(p => p.name).IsRequired().HasMaxLength(50);
        builder.Entity<Licor>().Property(p => p.description).IsRequired();
        builder.Entity<Licor>().Property(p => p.price).IsRequired();
    }

}