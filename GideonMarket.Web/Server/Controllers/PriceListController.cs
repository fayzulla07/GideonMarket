using GideonMarket.UseCases.Handlers.PriceLists.Queries;
using GideonMarket.UseCases.Handlers.PriceLists.Commands;
using GideonMarket.UseCases.Handlers.PriceLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GideonMarket.UseCases.Handlers.PriceListItems.Commands;
using GideonMarket.UseCases.Handlers.PriceListItems.Queries;

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

        #region PriceList
        [HttpGet]
        public async Task<IEnumerable<PriceListDto>> Get()
        {
            return await mediator.Send(new GetAllPriceListRequest());
        }



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
                Id = id,
                ItemIds = null
            });
        }
        #endregion

        #region PriceListItem
        [HttpGet("/Item")]
        public async Task<IEnumerable<GideonMarket.UseCases.Handlers.PriceListItems.PriceListItemDto>> GetItem()
        {
            return await mediator.Send(new GetAllPriceListItemRequest());
        }



        [HttpPost("Item")]
        public async Task<ActionResult<int>> CreateItem([FromBody] CreatePriceListItemRequest value)
        {
            return await mediator.Send(value);
        }


        [HttpPut("Item/{id}")]
        public async Task UpdateItem(int id, [FromBody] UpdatePriceListItemRequest value)
        {
            await mediator.Send(value);
        }


        [HttpDelete("Item/{id}")]
        public async Task DeleteItem(int id)
        {
            await mediator.Send(new DeletePriceListItemRequest()
            {
                Id = id
            });
        }
        #endregion


    }
}
