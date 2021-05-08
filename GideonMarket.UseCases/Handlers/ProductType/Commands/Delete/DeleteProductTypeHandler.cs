using AutoMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductType.Commands
{
    internal class DeleteProductTypeHandler : AsyncRequestHandler<DeleteProductTypeRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public DeleteProductTypeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(DeleteProductTypeRequest request, CancellationToken cancellationToken)
        {
            var productType = await appContext.ProductTypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.ProductTypes.Remove(productType);
            await appContext.SaveChangesAsync();
        }
    }
}
