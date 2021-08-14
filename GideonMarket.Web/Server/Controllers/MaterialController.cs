using GideonMarket.UseCases.Handlers.Products.Queries;
using GideonMarket.UseCases.Handlers.Products.Commands;
using GideonMarket.UseCases.Handlers.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMediator mediator;

        public MaterialController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await mediator.Send(new GetByMaterialProductRequest() { IsMaterial = true });
        }


    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductRequest value)
        {
            if(value != null)
            {
                value.IsMaterial = true;
            }
            return await mediator.Send(value);
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateProductRequest value)
        {
            await mediator.Send(value);
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteProductRequest()
            {
                Id = id
            });
        }
    }
}
