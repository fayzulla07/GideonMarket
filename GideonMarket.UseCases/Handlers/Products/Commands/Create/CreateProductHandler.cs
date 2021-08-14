using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;

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
            var product = request.Adapt<Product>();
            await appContext.Products.AddAsync(product);
            await appContext.SaveChangesAsync();
            return product.Id;
        }
    }
}
