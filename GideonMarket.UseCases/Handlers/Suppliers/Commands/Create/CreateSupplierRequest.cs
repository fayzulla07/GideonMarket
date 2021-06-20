using MediatR;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class CreateSupplierRequest : IRequest<int>
    {
        public SupplierDto dto { get; set; }
    }
}
