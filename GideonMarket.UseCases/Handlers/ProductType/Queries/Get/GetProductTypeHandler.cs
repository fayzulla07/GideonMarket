using AutoMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using GideonMarket.UseCases.Handlers.ProductType.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductType.Queries
{
    internal class GetProductTypeHandler : IRequestHandler<GetProductTypeRequest, ProductTypeDto>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public GetProductTypeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<ProductTypeDto> Handle(GetProductTypeRequest request, CancellationToken cancellationToken)
        {
            var productTypes = await appContext.ProductTypes.AsNoTracking().FirstOrDefaultAsync();
            var productTypeDtos = mapper.Map<ProductTypeDto>(productTypes);
            return productTypeDtos;
        }
    }
}
