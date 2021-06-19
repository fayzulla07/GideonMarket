using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Suppliers.Queries
{
    public class GetAllSupplierRequest : IRequest<IEnumerable<SupplierDto>>
    {
    }
}
