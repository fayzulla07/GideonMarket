using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    internal class UpdateUnitHandler : AsyncRequestHandler<UpdateUnitRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateUnitHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateUnitRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.Units.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            appContext.Entry(entity).CurrentValues.SetValues(new Domain.Models.Unit(request.dto.Id, request.dto.Name));
            await appContext.SaveChangesAsync();
        }
    }
}
