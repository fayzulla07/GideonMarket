using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    internal class CreatePlaceHandler : IRequestHandler<CreatePlaceRequest, int>
    {
        private readonly IAppContext appContext;
        public CreatePlaceHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreatePlaceRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope();
            var Place = request.dto.Adapt<Place>();
            await appContext.Places.AddAsync(Place);
            await appContext.SaveChangesAsync();
            scope.Complete();
            return Place.Id;
        }
    }
}
