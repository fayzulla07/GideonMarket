using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Models;
using GideonMarket.UseCases.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace GideonMarket.DataAccess.MsSql
{
    public class AppContext : DbContext, IAppContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
           
            Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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

            modelBuilder.Entity<Customers>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.FullName)
                .HasMaxLength(150)
                .IsRequired(true);
                x.HasIndex(i => i.FullName)
                .IsUnique();

                x.Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired(false);
            });

            modelBuilder.Entity<Unit>(x =>
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

            modelBuilder.Entity<Product>(x =>
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

                x.Property(p => p.Description)
                .HasMaxLength(150);

                x.Property(c => c.ProductTypeId).IsRequired();
                x.Property(c => c.UnitId).IsRequired();

                x.HasOne<ProductType>()
                .WithMany()
                .HasForeignKey(x => x.ProductTypeId);

                x.HasOne<Unit>()
                .WithMany()
                .HasForeignKey(x => x.UnitId);

                x.Property(x => x.Price).HasDefaultValue(0);

            });

            modelBuilder.Entity<Place>(x =>
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

                x.Property(p => p.PlaceType)
                .HasDefaultValue(PlaceType.WareHouse);
            });

            modelBuilder.Entity<PlaceItem>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
                x.Property(c => c.PlaceId).IsRequired();
                x.Property(c => c.ProductId).IsRequired();

                x.HasOne<Place>()
               .WithMany(x => x.PlaceItems)
               .HasForeignKey(x => x.PlaceId);

                x.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

                x.Property(x => x.RemainCount).HasDefaultValue(0);

            });

            modelBuilder.Entity<Income>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Description)
                .HasMaxLength(150)
                .IsRequired(true);

                x.Property(p => p.Number);
                x.HasIndex(i => i.Number)
               .IsUnique();


                x.Property(x => x.RegDt).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<IncomeItem>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
                x.Property(c => c.IncomeId).IsRequired();
                x.Property(c => c.ProductId).IsRequired();

                x.HasOne<Income>()
                .WithMany(x=>x.IncomeItems)
                .HasForeignKey(x => x.IncomeId);

                x.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

                x.Property(x => x.Price);

            });

            modelBuilder.Entity<Order>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Description)
                .HasMaxLength(150)
                .IsRequired(true);

                x.Property(p => p.Number);
                x.HasIndex(i => i.Number)
               .IsUnique();


                x.Property(x => x.RegDt);
            });

            modelBuilder.Entity<OrderItem>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Description)
               .HasMaxLength(150);

                x.Property(p => p.Count);

                x.Property(c => c.OrderId).IsRequired();
                x.Property(c => c.ProductId).IsRequired();

                x.HasOne<Order>()
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x => x.OrderId);

                x.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

                x.Property(x => x.Price);
                x.Property(x => x.OrderItemStatus).HasDefaultValue(OrderItemStatus.Completed);

            });

            modelBuilder.Entity<Customers>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.FullName)
                .HasMaxLength(150)
                .IsRequired(true);
                x.HasIndex(i => i.FullName)
                .IsUnique();

                x.Property(p => p.Email)
                .HasMaxLength(150);
                x.HasIndex(i => i.Email)
                .IsUnique();

            });

            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Login)
                .HasMaxLength(150)
                .IsRequired(true);
                x.HasIndex(i => i.Login)
               .IsUnique();

                x.Property(p => p.Email);
                x.HasIndex(i => i.Email)
               .IsUnique();

                x.Property(p => p.Password)
                .HasMaxLength(50)
                .IsRequired(true);

                x.HasOne(x => x.UserRole)
               .WithMany()
               .HasForeignKey(x => x.RoleId);

            });

            modelBuilder.Entity<Role>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                x.Property(p => p.Name)
               .HasMaxLength(150)
               .IsRequired();
            });
        }
    }
}
