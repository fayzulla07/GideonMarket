using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    internal class GetProductHandler : IRequestHandler<GetProductRequest, GetProductDto>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public GetProductHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<GetProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await appContext.Products.Where(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            var productDtos = mapper.Map<GetProductDto>(product);
            return productDtos;
        }
    }
}
