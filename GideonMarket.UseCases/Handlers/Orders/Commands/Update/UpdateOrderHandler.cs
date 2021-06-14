using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    internal class UpdateOrderHandler : AsyncRequestHandler<UpdateOrderRequest>
    {
        private readonly IAppContext appContext;

        public UpdateOrderHandler(IAppContext appContext)
        {
            this.appContext = appContext;

        }
        protected async override Task Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = await appContext.Orders.Include(x => x.OrderItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return;
            }
            request.Adapt(entity);
           // Обновить товары на складе
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var item in request.OrderItems)
            {
                place.UpdateOrder(item.ProductId, appContext.OrderItems.Where(x => x.Id == item.Id).FirstOrDefault().Count, item.Count);
                if(item.OrderItemStatus == Entities.Enums.OrderItemStatus.Canceled)
                {
                    place.CancelOrder(item.Id, item.Count);
                }
            }

            await appContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
