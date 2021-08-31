using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GideonMarket.Entities.Models;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    internal class UpdatePriceListHandler : AsyncRequestHandler<UpdatePriceListRequest>
    {
        private readonly IAppContext appContext;

        public UpdatePriceListHandler(IAppContext appContext)
        {
            this.appContext = appContext;

        }
        protected async override Task Handle(UpdatePriceListRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.PriceLists.Include(x => x.PriceItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return;
            }
            var adaptedValue = request.Adapt<PriceList>();
            entity.Name = adaptedValue.Name;
            entity.UpdateItem(entity.PriceItems);
            await appContext.SaveChangesAsync();
        }
    }
}
