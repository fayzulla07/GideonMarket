using MediatR;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class UpdateSupplierRequest : IRequest
    {
        public SupplierDto dto { get; set; }
    }
}
