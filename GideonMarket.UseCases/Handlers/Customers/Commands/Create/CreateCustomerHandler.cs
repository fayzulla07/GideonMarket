using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    internal class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, int>
    {
        private readonly IAppContext appContext;
        public CreateCustomerHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = request.dto.Adapt<Customer>();
            await appContext.Customers.AddAsync(customer);
            await appContext.SaveChangesAsync();
            return customer.Id;
        }
    }
}
