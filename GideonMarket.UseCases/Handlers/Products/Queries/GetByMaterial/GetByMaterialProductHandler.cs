using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    internal class GetByMaterialProductHandler : IRequestHandler<GetByMaterialProductRequest, IEnumerable<GetProductDto>>
    {
        private readonly IAppContext appContext;

        public GetByMaterialProductHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<GetProductDto>> Handle(GetByMaterialProductRequest request, CancellationToken cancellationToken)
        {
            var products = await appContext.Products.Where(x=>x.IsMaterial == request.IsMaterial).ToListAsync();
            var productDtos = products.Adapt<GetProductDto[]>();
            return productDtos;
        }
    }
}
