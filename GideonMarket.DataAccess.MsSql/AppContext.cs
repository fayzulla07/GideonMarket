using GideonMarket.Domain.Models;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace GideonMarket.DataAccess.MsSql
{
    public class AppContext : DbContext, IAppContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            modelBuilder.Entity<ProductType>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired(true);
                x.HasIndex(i => i.Name)
                .IsUnique();

            });
        }
    }
}
