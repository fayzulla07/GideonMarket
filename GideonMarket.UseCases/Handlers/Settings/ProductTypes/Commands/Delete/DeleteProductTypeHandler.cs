using GideonMarket.UseCases.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    internal class DeleteProductTypeHandler : AsyncRequestHandler<DeleteProductTypeRequest>
    {
        private readonly IAppContext appContext;

        public DeleteProductTypeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteProductTypeRequest request, CancellationToken cancellationToken)
        {
            var productType = await appContext.ProductTypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.ProductTypes.Remove(productType);
            await appContext.SaveChangesAsync();
        }
    }
}
