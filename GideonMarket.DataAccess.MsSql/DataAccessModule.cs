using GideonMarket.UseCases.DataAccess;
using GideonMarket.Utils.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GideonMarket.DataAccess.MsSql
{
    public class DataAccessModule : Module
    {
        public override void Load(IServiceCollection services)
        {
  
            services.AddDbContext<IAppContext, AppContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IGenericRepository, GenericRepository>();
        }
    }
}
