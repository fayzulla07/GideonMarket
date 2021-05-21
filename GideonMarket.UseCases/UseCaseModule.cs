using GideonMarket.UseCases.Validation;
using GideonMarket.Utils.Modules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Mapster;
using MapsterMapper;

namespace GideonMarket.DataAccess.MsSql
{
    public class UseCaseModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());


            var config = new TypeAdapterConfig();
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
