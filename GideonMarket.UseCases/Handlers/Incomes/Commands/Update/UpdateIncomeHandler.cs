using MapsterMapper;
using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GideonMarket.Entities.Models;
using System.Transactions;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    internal class UpdateIncomeHandler : AsyncRequestHandler<UpdateIncomeRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateIncomeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope();
            var entity = await appContext.Incomes.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
             var Income = mapper.Map<Income>(request.dto);
             appContext.Entry(entity).CurrentValues.SetValues(Income);
             await appContext.SaveChangesAsync();
             scope.Complete();
        }
    }
}
