
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    internal class DeleteSupplierHandler : AsyncRequestHandler<DeleteSupplierRequest>
    {
        private readonly IAppContext appContext;

        public DeleteSupplierHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
        {
            var Supplier = await appContext.Suppliers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Suppliers.Remove(Supplier);
            await appContext.SaveChangesAsync();
        }
    }
}
