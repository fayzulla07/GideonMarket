using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    internal class GetAllProductHandler : IRequestHandler<GetAllProductRequest, IEnumerable<ProductDto>>
    {
        private readonly IAppContext appContext;

        public GetAllProductHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await appContext.Products.ToListAsync();
            var productDtos = products.Adapt<ProductDto[]>();
            return productDtos;
        }
    }
}
