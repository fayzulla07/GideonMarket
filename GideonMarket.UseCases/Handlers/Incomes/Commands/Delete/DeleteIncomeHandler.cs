
using GideonMarket.UseCases.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class DeleteIncomeHandler : AsyncRequestHandler<DeleteIncomeRequest>
    {
        private readonly IAppContext appContext;

        public DeleteIncomeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(DeleteIncomeRequest request, CancellationToken cancellationToken)
        {
            var Income = await appContext.Incomes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Incomes.Remove(Income);
            await appContext.SaveChangesAsync();
        }
    }
}
