using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Customers.Queries
{
    internal class GetAllCutomerHandler : IRequestHandler<GetAllCustomerRequest, IEnumerable<CustomerDto>>
    {
        private readonly IAppContext appContext;

        public GetAllCutomerHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
        {
            var customers = await appContext.Customers.ToListAsync();
            var customerDtos = customers.Adapt<CustomerDto[]>();
            return customerDtos;
        }
    }
   
}
