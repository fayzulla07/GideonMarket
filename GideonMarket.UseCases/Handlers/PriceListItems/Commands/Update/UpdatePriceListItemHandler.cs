using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GideonMarket.Entities.Models;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    internal class UpdatePriceListItemHandler : AsyncRequestHandler<UpdatePriceListItemRequest>
    {
        private readonly IGenericRepository repository;

        public UpdatePriceListItemHandler(IGenericRepository repository)
        {
            this.repository = repository;
        }
        protected async override Task Handle(UpdatePriceListItemRequest request, CancellationToken cancellationToken)
        {
            var mappedvalue = request.Adapt<PriceListItem>();
            repository.Update(mappedvalue);
            await repository.SaveAsync();

        }
    }
}
