using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    internal class CreateSupplierHandler : IRequestHandler<CreateSupplierRequest, int>
    {
        private readonly IAppContext appContext;
        public CreateSupplierHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            var Supplier = request.dto.Adapt<Supplier>();
            await appContext.Suppliers.AddAsync(Supplier);
            await appContext.SaveChangesAsync();
            return Supplier.Id;
        }
    }
}
