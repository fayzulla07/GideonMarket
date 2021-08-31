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
        private readonly IGenericRepository repository;

        public CreatePriceListHandler(IAppContext appContext, IGenericRepository repository)
        {
            this.appContext = appContext;
            this.repository = repository;
        }
        public async Task<int> Handle(CreatePriceListRequest request, CancellationToken cancellationToken)
        {
            // mapped request
            var priceList = request.Adapt<PriceList>();
            
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            //// object to save
            //PriceList pricelst = new();
            //pricelst.Name = priceList.Name;
            //pricelst.Id = priceList.Id;
            //// Добавить приход
            //pricelst.AddItem(priceList.PriceItems);
            //add to repository
            repository.AddOrUpdate(priceList);
            await repository.SaveAsync();
            scope.Complete();
            return priceList.Id;
        }
    }
}
