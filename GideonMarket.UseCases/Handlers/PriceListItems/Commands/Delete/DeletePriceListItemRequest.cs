using MediatR;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    public class DeletePriceListItemRequest : IRequest
    {
        public int PriceListId { get; set; }
        public int Id { get; set; }
    }
}
