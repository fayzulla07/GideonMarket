using GideonMarket.UseCases.Handlers.ProductTypes.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    public class UpdateProductTypeRequest : IRequest
    {
        
        public ProductTypeDto dto { get; set; }
    }
}
