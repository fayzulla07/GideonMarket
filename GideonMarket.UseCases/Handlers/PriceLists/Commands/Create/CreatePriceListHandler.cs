using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    internal class CreatePriceListHandler : IRequestHandler<CreatePriceListRequest, int>
    {
        private readonly IAppContext appContext;
        public CreatePriceListHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreatePriceListRequest request, CancellationToken cancellationToken)
        {
            var PriceList = request.Adapt<PriceList>();
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            // Добавить приход
            await appContext.PriceLists.AddAsync(PriceList);

            await appContext.SaveChangesAsync();
            scope.Complete();
            return PriceList.Id;
        }
    }
}
