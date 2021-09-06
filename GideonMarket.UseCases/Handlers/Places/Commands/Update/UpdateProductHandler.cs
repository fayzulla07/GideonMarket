using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;
using Mapster;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    internal class UpdatePlaceHandler : AsyncRequestHandler<UpdatePlaceRequest>
    {
        private readonly IAppContext appContext;

        public UpdatePlaceHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(UpdatePlaceRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope();
            var entity = await appContext.Places.FindAsync(request.Id);
            if (entity == null)
            {
                return;
            }
            var place = request.Adapt<Place>();
             appContext.Entry(entity).CurrentValues.SetValues(place);
             await appContext.SaveChangesAsync();
             scope.Complete();
        }
    }
}
