
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    internal class DeleteOrderHandler : AsyncRequestHandler<DeleteOrderRequest>
    {
        private readonly IAppContext appContext;

        public DeleteOrderHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var Order = await appContext.Orders.Include(x => x.OrderItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Orders.Remove(Order);

            // Удалить товар из склада
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == Order.PlaceId).FirstOrDefaultAsync();
            foreach (var item in Order.OrderItems)
            {
                place.DeleteOrder(item.ProductId, item.Count);
            }

            await appContext.SaveChangesAsync();
            
            scope.Complete();
        }
    }
}
