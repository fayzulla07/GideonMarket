using Mapster;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    internal class UpdateUnitHandler : AsyncRequestHandler<UpdateUnitRequest>
    {
        private readonly IAppContext appContext;

        public UpdateUnitHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(UpdateUnitRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.Units.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            request.dto.Adapt(entity);
            await appContext.SaveChangesAsync();


        }
    }
}
