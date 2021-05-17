﻿using GideonMarket.UseCases.Handlers.Products.Dto;
using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class UpdateProductRequest : IRequest
    {
        
        public SetProductDto dto { get; set; }
    }
}
