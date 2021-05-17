using GideonMarket.UseCases.Handlers.Units.Commands;
using GideonMarket.UseCases.Handlers.Units.Dto;
using GideonMarket.UseCases.Handlers.Units.Queries.Get;
using GideonMarket.UseCases.Handlers.Units.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public UnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IEnumerable<UnitDto>> Get()
        {
            return await mediator.Send(new GetAllUnitRequest());
        }

        
        [HttpGet("{id}")]
        public async Task<UnitDto> Get(int id)
        {
            return await mediator.Send(new GetUnitRequest()
            {
                Id = id
            });
        }

    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] string value)
        {
            return await mediator.Send(new CreateUnitRequest()
            {
               dto =  new UnitDto() { Name = value }
            });
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] string value)
        {
            await mediator.Send(new UpdateUnitRequest()
            {
                dto = new UnitDto() { Name = value, Id = id }
            });
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteUnitRequest()
            {
                Id = id
            });
        }
    }
}
