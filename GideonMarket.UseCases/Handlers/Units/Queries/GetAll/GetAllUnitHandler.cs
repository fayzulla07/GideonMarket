using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using GideonMarket.UseCases.Handlers.Units.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Units.Queries.GetAll
{
    internal class GetAllUnitHandler : IRequestHandler<GetAllUnitRequest, IEnumerable<UnitDto>>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public GetAllUnitHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UnitDto>> Handle(GetAllUnitRequest request, CancellationToken cancellationToken)
        {
            var units = await appContext.Units.ToListAsync();
            var unitDtos = mapper.Map<UnitDto[]>(units);
            return unitDtos;
        }
    }
}
