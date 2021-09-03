using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Mapster;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    internal class CreateUnitHandler : IRequestHandler<CreateUnitRequest, int>
    {
        private readonly IAppContext appContext;

        public CreateUnitHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<int> Handle(CreateUnitRequest request, CancellationToken cancellationToken)
        {
            var unit = request.dto.Adapt<Entities.Models.Unit>();
            await appContext.Units.AddAsync(unit);
            await appContext.SaveChangesAsync();
            return unit.Id;
        }
    }
}
