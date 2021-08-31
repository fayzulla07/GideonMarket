using MediatR;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class DeletePriceListRequest : IRequest
    {
        public int Id { get; set; }
        public int[] ItemIds { get; set; }
    }
}
