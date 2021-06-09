using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class UpdateIncomeHandler : AsyncRequestHandler<UpdateIncomeRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateIncomeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var income = mapper.Map<Income>(request);
            var entity = await appContext.Incomes.Where(x => x.Id == income.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return;
            }
            appContext.Entry(entity).CurrentValues.SetValues(income);
            appContext.IncomeItems.UpdateRange(income.IncomeItems);

            // Добавить товар на склад
            var place = await appContext.Places.Include(x => x.PlaceItems).Where(x => x.Id == request.PlaceId).FirstOrDefaultAsync();
            foreach (var item in income.IncomeItems)
            {
                place.UpdateProductInPlace(item.ProductId, item.Count);
            }

            await appContext.SaveChangesAsync();
             scope.Complete();
        }
    }
}
