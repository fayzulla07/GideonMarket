using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.Utils.Modules
{
   public static class ServiceCollectionExtensions
    {
        public static void RegisterModule<T>(this IServiceCollection serviceCollection, IConfiguration configuration)
            where T : Module
        {
            var module = Activator.CreateInstance<T>();

            module.Configuration = configuration;

            module.Load(serviceCollection);
        }
    }
}
