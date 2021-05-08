using GideonMarket.UseCases.Handlers.ProductType.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.ProductType.Commands
{
    public class CreateProductTypeRequest : IRequest<int>
    {
        public ProductTypeDto dto { get; set; }
    }
}
