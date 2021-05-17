using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using GideonMarket.UseCases.Handlers.Units.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Units.Queries.Get
{
    internal class GetUnitHandler : IRequestHandler<GetUnitRequest, UnitDto>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public GetUnitHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        public async Task<UnitDto> Handle(GetUnitRequest request, CancellationToken cancellationToken)
        {
            var units = await appContext.Units.Where(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            var unitDtos = mapper.Map<UnitDto>(units);
            return unitDtos;
        }
    }
}
