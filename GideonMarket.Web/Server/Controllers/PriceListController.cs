using GideonMarket.UseCases.Handlers.PriceLists.Queries;
using GideonMarket.UseCases.Handlers.PriceLists.Commands;
using GideonMarket.UseCases.Handlers.PriceLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly IMediator mediator;

        public PriceListController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IEnumerable<PriceListDto>> Get()
        {
            return await mediator.Send(new GetAllPriceListRequest());
        }

        
        //[HttpGet("{id}")]
        //public async Task<PriceListDto> Get(int id)
        //{
        //    return await mediator.Send(new PriceListRequest()
        //    {
        //        Id = id
        //    });
        //}

    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePriceListRequest value)
        {
            return await mediator.Send(value);
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdatePriceListRequest value)
        {
            await mediator.Send(value);
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeletePriceListRequest()
            {
                Id = id
            });
        }
    }
}
