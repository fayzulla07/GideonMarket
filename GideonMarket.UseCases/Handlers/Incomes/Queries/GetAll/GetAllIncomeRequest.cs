using GideonMarket.UseCases.Handlers.Incomes;
using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Incomes.Queries
{
    public class GetAllIncomeRequest : IRequest<IEnumerable<IncomeDto>>
    {
    }
}
