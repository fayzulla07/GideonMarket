
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    internal class DeletePlaceHandler : AsyncRequestHandler<DeletePlaceRequest>
    {
        private readonly IAppContext appContext;

        public DeletePlaceHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeletePlaceRequest request, CancellationToken cancellationToken)
        {
            var Place = await appContext.Places.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Places.Remove(Place);
            await appContext.SaveChangesAsync();
        }
    }
}
