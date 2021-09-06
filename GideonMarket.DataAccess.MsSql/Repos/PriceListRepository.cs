using GideonMarket.Entities.Models;
using GideonMarket.UseCases.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GideonMarket.DataAccess.MsSql.Repos
{
    public class PriceListRepository 
    {
        private readonly IAppContext appContext;

        public PriceListRepository(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task AddAsync(PriceList entity)
        {
            var result = await appContext.PriceLists.Include(x => x.PriceItems).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if(result != null)
            {
                result.PriceItems.AddRange(entity.PriceItems);
            }
            else
            {
                await appContext.PriceLists.AddAsync(entity);
            }

        }

        public async Task DeleteAsync(int id)
        {
            var result = await appContext.PriceLists.FirstOrDefaultAsync(x => x.Id == id);
            if(result != null)
            {
                appContext.PriceLists.Remove(result);
            }
        }

        public async Task DeleteItemAsync(int id, int itemid) 
        {
            var result = await appContext.PriceLists.Include(x => x.PriceItems).FirstOrDefaultAsync(x => x.Id == id);
            var datatoremove = result.PriceItems.FirstOrDefault(x => x.Id == itemid);
            result.PriceItems.Remove(datatoremove);
        }

        public async Task<PriceList> FindById(int id)
        {
            var result = await appContext.PriceLists.Include(x => x.PriceItems).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<PriceList>> GetAsync()
        {
            var result = await appContext.PriceLists.Include(x => x.PriceItems).ToListAsync();
            return result;
        }

        public async Task<int> SaveAsync()
        {
          return await appContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PriceList entity)
        {
            var result = await appContext.PriceLists.Include(x => x.PriceItems).Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            result.Name = entity.Name;
            if (result.PriceItems.Any())
            {
                foreach (var item in result.PriceItems)
                {
                    if(item.Id == entity.Id)
                    {
                       // item.ManualPrice = entity.
                    }
                }
            }
        }
    }
}
