using GideonMarket.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.DataAccess
{
    public interface IAppContext
    {
        DbSet<ProductType> ProductTypes { get; }
        DbSet<Unit> Units { get; }
        DbSet<Product> Products { get; }
        public DbSet<Place> Places { get; }
        public DbSet<Income> Incomes { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Customer> Customers { get; }
        public DbSet<User> Users { get; }
        public DbSet<Role> Roles { get; }
        public DbSet<Supplier> Suppliers { get; }

        public DbSet<PlaceItem> PlaceItems { get;  }
        public DbSet<IncomeItem> IncomeItems { get;  }
        public DbSet<OrderItem> OrderItems { get;  }
        public DbSet<PriceList> PriceLists { get; }
        public DbSet<PriceListItem> PriceListItems { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Entry(object entity);
        
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        DatabaseFacade Database { get; }
    }
}
