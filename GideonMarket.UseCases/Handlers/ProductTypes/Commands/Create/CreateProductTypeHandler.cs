using MapsterMapper;
using GideonMarket.Domain.Models;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using GideonMarket.UseCases.Handlers.ProductTypes.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    internal class CreateProductTypeHandler : IRequestHandler<CreateProductTypeRequest, int>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public CreateProductTypeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var producttype = new Domain.Models.ProductType(request.dto.Name);
            await appContext.ProductTypes.AddAsync(producttype);
            await appContext.SaveChangesAsync();
            return producttype.Id;
        }
    }
}
