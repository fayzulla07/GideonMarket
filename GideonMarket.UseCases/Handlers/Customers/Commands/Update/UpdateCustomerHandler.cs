using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    internal class UpdateCustomerHandler : AsyncRequestHandler<UpdateCustomerRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateCustomerHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.Customers.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            var Customer = mapper.Map<Customer>(request.dto);
            appContext.Entry(entity).CurrentValues.SetValues(Customer);
            await appContext.SaveChangesAsync();
        }
    }
}
