using GideonMarket.UseCases.Handlers.ProductType.Commands;
using GideonMarket.UseCases.Handlers.ProductType.Dto;
using GideonMarket.UseCases.Handlers.ProductType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IEnumerable<ProductTypeDto>> Get()
        {
            return await mediator.Send(new GetAllProductTypeRequest());
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] string value)
        {
            return await mediator.Send(new CreateProductTypeRequest()
            {
               dto =  new ProductTypeDto() { Name = value }
            });
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] string value)
        {
            await mediator.Send(new UpdateProductTypeRequest()
            {
                dto = new ProductTypeDto() { Name = value, Id = id }
            });
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteProductTypeRequest()
            {
                Id = id
            });
        }
    }
}
