using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class UpdateIncomeHandler : AsyncRequestHandler<UpdateIncomeRequest>
    {
        private readonly IAppContext appContext;

        public UpdateIncomeHandler(IAppContext appContext)
        {
            this.appContext = appContext;

        }
        protected async override Task Handle(UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = await appContext.Incomes.Include(x => x.IncomeItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return;
            }
            request.Adapt(entity);
           // Обновить товары на складе
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var item in request.IncomeItems)
            {
                double oldCount = appContext.IncomeItems.Where(x => x.Id == item.Id).FirstOrDefault().Count;
                if (item.Count > oldCount)
                {
                    place.AddCount(item.ProductId, (item.Count - oldCount));
                }
                else if (item.Count < oldCount)
                {
                    place.ReduceCount(item.ProductId, (oldCount - item.Count));
                }
            }

            await appContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
