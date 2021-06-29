using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    internal class CreateOrderHandler : IRequestHandler<CreateOrderRequest, int>
    {
        private readonly IAppContext appContext;
        public CreateOrderHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            // Добавить приход
            await appContext.Orders.AddAsync(order);

            // Добавить товар на склад
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var item in order.OrderItems)
            {
                item.ChangeStatus(Entities.Enums.OrderItemStatus.Ordered);
                place.ReduceCount(item.ProductId, item.Count);
            }

            await appContext.SaveChangesAsync();
            scope.Complete();
            return order.Id;
        }
    }
}
