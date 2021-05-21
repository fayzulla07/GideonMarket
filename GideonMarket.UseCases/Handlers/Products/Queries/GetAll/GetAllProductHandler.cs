
using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    internal class GetAllProductHandler : IRequestHandler<GetAllProductRequest, IEnumerable<GetProductDto>>
    {
        private readonly IAppContext appContext;

        public GetAllProductHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await appContext.Products.ToListAsync();
            var productDtos = products.Adapt<GetProductDto[]>();
            return productDtos;
        }
    }
}
