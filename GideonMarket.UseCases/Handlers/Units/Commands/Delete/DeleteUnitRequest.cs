using GideonMarket.UseCases.Handlers.ProductTypes.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class DeleteUnitRequest : IRequest
    {
        public int Id { get; set; }
    }
}
