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

namespace GideonMarket.UseCases.Handlers.Suppliers.Queries
{
    internal class GetAllCutomerHandler : IRequestHandler<GetAllSupplierRequest, IEnumerable<SupplierDto>>
    {
        private readonly IAppContext appContext;

        public GetAllCutomerHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<SupplierDto>> Handle(GetAllSupplierRequest request, CancellationToken cancellationToken)
        {
            var Suppliers = await appContext.Suppliers.ToListAsync();
            var SupplierDtos = Suppliers.Adapt<SupplierDto[]>();
            return SupplierDtos;
        }
    }
   
}
