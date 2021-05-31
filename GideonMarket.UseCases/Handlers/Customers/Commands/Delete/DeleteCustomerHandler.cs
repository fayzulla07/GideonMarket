
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    internal class DeleteCustomerHandler : AsyncRequestHandler<DeleteCustomerRequest>
    {
        private readonly IAppContext appContext;

        public DeleteCustomerHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var Customer = await appContext.Customers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Customers.Remove(Customer);
            await appContext.SaveChangesAsync();
        }
    }
}
