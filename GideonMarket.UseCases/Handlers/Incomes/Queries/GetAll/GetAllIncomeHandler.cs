using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Incomes.Queries
{
    internal class GetAllIncomeHandler : IRequestHandler<GetAllIncomeRequest, IEnumerable<IncomeDto>>
    {
        private readonly IAppContext appContext;

        public GetAllIncomeHandler(IAppContext appContext)   
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<IncomeDto>> Handle(GetAllIncomeRequest request, CancellationToken cancellationToken)
        {
            var incomes = await appContext.Incomes.Include(x => x.IncomeItems).ToListAsync();
            var incomeDtos = incomes.Adapt<IncomeDto[]>();
            return incomeDtos;
        }
    }
}
