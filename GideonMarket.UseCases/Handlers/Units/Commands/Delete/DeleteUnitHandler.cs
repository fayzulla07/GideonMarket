using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    internal class DeleteUnitHandler : AsyncRequestHandler<DeleteUnitRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public DeleteUnitHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(DeleteUnitRequest request, CancellationToken cancellationToken)
        {
            var unit = await appContext.Units.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Units.Remove(unit);
            await appContext.SaveChangesAsync();
        }
    }
}
