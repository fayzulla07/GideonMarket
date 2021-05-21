using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Queries
{
    internal class GetAllProductTypeHandler : IRequestHandler<GetAllProductTypeRequest, IEnumerable<ProductTypeDto>>
    {
        private readonly IAppContext appContext;

        public GetAllProductTypeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<ProductTypeDto>> Handle(GetAllProductTypeRequest request, CancellationToken cancellationToken)
        {
            var productTypes = await appContext.ProductTypes.ToListAsync();
            List<ProductTypeDto> productTypeDtos = new List<ProductTypeDto>();
            foreach (var item in productTypes)
            {
                productTypeDtos.Add(new ProductTypeDto() { Id = item.Id, Name = item.Name });
            }
            return productTypeDtos;
        }
    }
}
