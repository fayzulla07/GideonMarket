using GideonMarket.Entities.Shared;
using GideonMarket.UseCases.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.DataAccess.MsSql
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IAppContext appContext;

        public GenericRepository(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<List<T>> GetAsync<T>() where T : Entity
        {
            return await appContext.Set<T>().ToListAsync();
        }
        public async Task<T> FindById<T>(int id) where T : Entity
        {
            return await appContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync<T>(T entity) where T : Entity
        {
            await appContext.Set<T>().AddAsync(entity);
        }
        public async Task AddAsync<T>(List<T> entity) where T : Entity
        {
            await appContext.Set<T>().AddRangeAsync(entity);
        }
        public void AddOrUpdate<T>(T entity) where T : Entity
        {
            appContext.Set<T>().Update(entity);
        }
        public void Update<T>(T entity) where T : Entity
        {
            appContext.Set<T>().Update(entity);
        }
        public void Update<T>(List<T> entity) where T : Entity
        {
            appContext.Set<T>().UpdateRange(entity);
        }
        public async Task DeleteAsync<T>(int id) where T : Entity
        {
            var value = await appContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            appContext.Set<T>().Remove(value);
        }
        public async Task DeleteAsync<T>(int[] ids) where T : Entity
        {
            var value = await appContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
            appContext.Set<T>().RemoveRange(value);
        }
        public async Task<int> SaveAsync()
        {
            return await appContext.SaveChangesAsync();
        }
    }
}
