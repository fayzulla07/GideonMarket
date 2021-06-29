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
                double oldCount = entity.GetItem(requestitem.Id).Count;
                // обновляем количество
                if (requestitem.Count > oldCount)
                {
                    place.ReduceCount(requestitem.ProductId, (oldCount - requestitem.Count));
                }
                else if (requestitem.Count < oldCount)
                {
                    place.AddCount(requestitem.ProductId, (requestitem.Count - oldCount));
                }

                // если состояние поменялся на Ordered
                if (requestitem.OrderItemStatus != entity.GetItem(requestitem.Id).OrderItemStatus && requestitem.OrderItemStatus == Entities.Enums.OrderItemStatus.Ordered)
                {
                    place.ReduceCount(requestitem.ProductId, requestitem.Count);
                }
                // если состояние поменялся на Canceled
                else if (requestitem.OrderItemStatus != entity.GetItem(requestitem.Id).OrderItemStatus && requestitem.OrderItemStatus == Entities.Enums.OrderItemStatus.Canceled)
                {
                    place.AddCount(requestitem.ProductId, requestitem.Count);
                }
            }

            request.Adapt(entity);
            await appContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
