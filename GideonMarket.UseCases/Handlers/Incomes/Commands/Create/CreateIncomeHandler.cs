using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using GideonMarket.Entities.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class CreateIncomeHandler : IRequestHandler<CreateIncomeRequest, int>
    {
        private readonly IAppContext appContext;
        public CreateIncomeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var income = request.Adapt<Income>();
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            // Добавить приход
            await appContext.Incomes.AddAsync(income);

            // Добавить товар на склад
            var place = await appContext.Places.Include(x=>x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var item in income.IncomeItems)
            {
                place.AddProductToPlace(item.ProductId, item.Count);
            }

            await appContext.SaveChangesAsync();
            scope.Complete();
            return income.Id;
        }
    }
}
