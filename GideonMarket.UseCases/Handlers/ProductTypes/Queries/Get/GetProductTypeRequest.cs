using GideonMarket.UseCases.Handlers.ProductTypes.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Queries
{
    public class GetProductTypeRequest : IRequest<ProductTypeDto>
    {
        public int Id { get; set; }
    }
}
