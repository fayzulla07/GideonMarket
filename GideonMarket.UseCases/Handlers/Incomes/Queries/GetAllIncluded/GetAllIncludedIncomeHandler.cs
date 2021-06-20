using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Incomes.Queries
{
    internal class GetAllIncludedIncomeHandler : IRequestHandler<GetAllIncludedIncomeRequest, IEnumerable<IncomeItemDto>>
    {
        private readonly IAppContext appContext;

        public GetAllIncludedIncomeHandler(IAppContext appContext)   
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<IncomeItemDto>> Handle(GetAllIncludedIncomeRequest request, CancellationToken cancellationToken)
        {

            //var incomeDtos = await appContext.Incomes.Include(x => x.IncomeItems)
            //    .SelectMany((x, p) => x.IncomeItems, new IncomeItemDto() 
            //    {
            //       Count = p.
            //    })
            //    .AsNoTracking().ToListAsync();
            //return incomeDtos;
            return null;
        }
    }
}
