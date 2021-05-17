using GideonMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.Infrastructure.Interfaces.DataAccess
{
    public interface IAppContext
    {
        DbSet<ProductType> ProductTypes { get; }
        DbSet<Unit> Units { get; }
        DbSet<Product> Products { get; }
        public DbSet<Place> Places { get; }
        public DbSet<Income> Incomes { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Client> Clients { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Entry(object entity);
        
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
