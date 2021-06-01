using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    internal class UpdatePlaceHandler : AsyncRequestHandler<UpdatePlaceRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdatePlaceHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdatePlaceRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope();
            var entity = await appContext.Places.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
             var place = mapper.Map<Place>(request.dto);
             appContext.Entry(entity).CurrentValues.SetValues(place);
             await appContext.SaveChangesAsync();
             scope.Complete();
        }
    }
}
