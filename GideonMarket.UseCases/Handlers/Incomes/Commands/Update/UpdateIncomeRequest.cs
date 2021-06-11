using MediatR;
using System;
using System.Collections.Generic;
using Mapster;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class UpdateIncomeRequest : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public DateTime RegDt { get; set; }

        
        public List<IncomeItemDto> IncomeItems { get; set; }
        public int PlaceId { get; set; }
    }
}
