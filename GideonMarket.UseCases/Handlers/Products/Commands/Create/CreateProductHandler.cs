using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MapsterMapper;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Domain.Models;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    internal class CreateProductHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IAppContext appContext;
        public CreateProductHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.dto.Adapt<Product>();
            await appContext.Products.AddAsync(product);
            await appContext.SaveChangesAsync();
            return product.Id;
        }
    }
}
