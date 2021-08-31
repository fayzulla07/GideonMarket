
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    internal class DeletePriceListItemHandler : AsyncRequestHandler<DeletePriceListItemRequest>
    {
        private readonly IAppContext appContext;

        public DeletePriceListItemHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeletePriceListItemRequest request, CancellationToken cancellationToken)
        {
            var PriceListItem = await appContext.PriceListItems.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.PriceListItems.Remove(PriceListItem);


            await appContext.SaveChangesAsync();
        }
    }
}
