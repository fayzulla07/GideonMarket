using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Customers.Queries
{
    internal class GetCutomerHandler : IRequestHandler<GetCustomerRequest, CustomerDto>
    {
        private readonly IAppContext appContext;

        public GetCutomerHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<CustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await appContext.Customers.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();
            var customerDtos = customer.Adapt<CustomerDto>();
            return customerDtos;
        }
    }
   
}
