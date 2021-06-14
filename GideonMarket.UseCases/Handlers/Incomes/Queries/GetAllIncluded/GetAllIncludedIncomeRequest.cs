using GideonMarket.UseCases.Handlers.Incomes;
using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Incomes.Queries
{
    public class GetAllIncludedIncomeRequest : IRequest<IEnumerable<IncomeItemDto>>
    {
    }
}
