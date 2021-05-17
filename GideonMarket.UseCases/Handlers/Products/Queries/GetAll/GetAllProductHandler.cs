
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using GideonMarket.UseCases.Handlers.Products.Dto;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Queries.GetAll
{
    internal class GetAllProductHandler : IRequestHandler<GetAllProductRequest, IEnumerable<GetProductDto>>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public GetAllProductHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await appContext.Products.ToListAsync();
            var productDtos = mapper.Map<GetProductDto[]>(products);
            return productDtos;
        }
    }
}
