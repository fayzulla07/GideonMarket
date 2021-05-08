using GideonMarket.UseCases.Handlers.ProductType.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.ProductType.Queries
{
    public class GetProductTypeRequest : IRequest<ProductTypeDto>
    {
        [Required]
        public int Id { get; set; }
    }
}
