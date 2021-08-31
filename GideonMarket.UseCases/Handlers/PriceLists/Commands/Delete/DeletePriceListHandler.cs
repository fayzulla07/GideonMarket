
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    internal class DeletePriceListHandler : AsyncRequestHandler<DeletePriceListRequest>
    {
        private readonly IAppContext appContext;

        public DeletePriceListHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeletePriceListRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var priceList = await appContext.PriceLists.Include(x => x.PriceItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.PriceLists.Remove(priceList);

            await appContext.SaveChangesAsync();
            
            scope.Complete();
        }
    }
}
