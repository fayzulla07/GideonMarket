
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class DeleteIncomeHandler : AsyncRequestHandler<DeleteIncomeRequest>
    {
        private readonly IAppContext appContext;

        public DeleteIncomeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteIncomeRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var income = await appContext.Incomes.Include(x => x.IncomeItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Incomes.Remove(income);

            // Удалить товар из склада
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == income.PlaceId).FirstOrDefaultAsync();
            foreach (var item in income.IncomeItems)
            {
                place.RemoveProductFromPlace(item.ProductId, item.Count);
            }

            await appContext.SaveChangesAsync();
            
            scope.Complete();
        }
    }
}
