using GideonMarket.UseCases.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Queries
{
    internal class GetProductTypeHandler : IRequestHandler<GetProductTypeRequest, ProductTypeDto>
    {
        private readonly IAppContext appContext;

        public GetProductTypeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<ProductTypeDto> Handle(GetProductTypeRequest request, CancellationToken cancellationToken)
        {
            var productTypes = await appContext.ProductTypes.Where(x=>x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            var productTypeDtos = productTypes.Adapt<ProductTypeDto>();
            return productTypeDtos;
        }
    }
}
