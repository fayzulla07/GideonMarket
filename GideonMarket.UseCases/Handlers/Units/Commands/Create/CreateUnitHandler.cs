using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Mapster;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    internal class CreateUnitHandler : IRequestHandler<CreateUnitRequest, int>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public CreateUnitHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateUnitRequest request, CancellationToken cancellationToken)
        {
            var unit = request.dto.Adapt<Domain.Models.Unit>();
            await appContext.Units.AddAsync(unit);
            await appContext.SaveChangesAsync();
            return unit.Id;
        }
    }
}
