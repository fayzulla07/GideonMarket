using GideonMarket.UseCases.Handlers.ProductType.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.ProductType.Commands
{
    public class DeleteProductTypeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
