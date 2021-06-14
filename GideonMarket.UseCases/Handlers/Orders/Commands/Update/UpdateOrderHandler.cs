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
           // Обновить товары на складе
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var requestitem in request.OrderItems)
            {
                // обновляем количество
                 place.UpdateOrder(requestitem.ProductId, entity.GetItem(requestitem.Id).Count, requestitem.Count);

                // если состояние поменялся на Ordered
                if (requestitem.OrderItemStatus != entity.GetItem(requestitem.Id).OrderItemStatus && requestitem.OrderItemStatus == Entities.Enums.OrderItemStatus.Ordered)
                {
                    place.ReCancelOrder(requestitem.ProductId, requestitem.Count);
                }
                // если состояние поменялся на Canceled
                else if (requestitem.OrderItemStatus != entity.GetItem(requestitem.Id).OrderItemStatus && requestitem.OrderItemStatus == Entities.Enums.OrderItemStatus.Canceled)
                {
                    place.CancelOrder(requestitem.ProductId, requestitem.Count);
                }
            }

            request.Adapt(entity);
            await appContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
