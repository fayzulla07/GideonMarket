using MediatR;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class DeleteSupplierRequest : IRequest
    {
        public int Id { get; set; }
    }
}
