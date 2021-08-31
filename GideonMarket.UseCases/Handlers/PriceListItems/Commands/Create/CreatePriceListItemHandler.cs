using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    internal class CreatePriceListItemHandler : IRequestHandler<CreatePriceListItemRequest, int>
    {
        private readonly IAppContext appContext;
        private readonly IGenericRepository repository;

        public CreatePriceListItemHandler(IAppContext appContext, IGenericRepository repository)
        {
            this.appContext = appContext;
            this.repository = repository;
        }
        public async Task<int> Handle(CreatePriceListItemRequest request, CancellationToken cancellationToken)
        {
            // mapped request
            var priceListItem = request.Adapt<PriceListItem>();
            await repository.AddAsync(priceListItem);
            await repository.SaveAsync();
            return priceListItem.Id;
        }
    }
}
