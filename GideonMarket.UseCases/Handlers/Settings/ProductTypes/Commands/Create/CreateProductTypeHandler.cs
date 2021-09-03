using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    internal class CreateProductTypeHandler : IRequestHandler<CreateProductTypeRequest, int>
    {
        private readonly IAppContext appContext;

        public CreateProductTypeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var producttype = new Entities.Models.ProductType(request.dto.Name);
            await appContext.ProductTypes.AddAsync(producttype);
            await appContext.SaveChangesAsync();
            return producttype.Id;
        }
    }
}
