using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            request.Adapt(entity);
            await appContext.SaveChangesAsync();
        }
    }
}
