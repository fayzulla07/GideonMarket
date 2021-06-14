using GideonMarket.UseCases.Handlers.Orders.Queries;
using GideonMarket.UseCases.Handlers.Orders.Commands;
using GideonMarket.UseCases.Handlers.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get()
        {
            return await mediator.Send(new GetAllOrderRequest());
        }

        
        //[HttpGet("{id}")]
        //public async Task<OrderDto> Get(int id)
        //{
        //    return await mediator.Send(new OrderRequest()
        //    {
        //        Id = id
        //    });
        //}

    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateOrderRequest value)
        {
            return await mediator.Send(value);
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateOrderRequest value)
        {
            await mediator.Send(value);
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteOrderRequest()
            {
                Id = id
            });
        }
    }
}
