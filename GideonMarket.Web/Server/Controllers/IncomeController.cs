using GideonMarket.UseCases.Handlers.Incomes.Queries;
using GideonMarket.UseCases.Handlers.Incomes.Commands;
using GideonMarket.UseCases.Handlers.Incomes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IMediator mediator;

        public IncomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<IncomeDto>> Get()
        {
            return await mediator.Send(new GetAllIncomeRequest());
        }

        
        //[HttpGet("{id}")]
        //public async Task<IncomeDto> Get(int id)
        //{
        //    return await mediator.Send(new IncomeRequest()
        //    {
        //        Id = id
        //    });
        //}

    
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateIncomeRequest value)
        {
            return await mediator.Send(value);
        }

       
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateIncomeRequest value)
        {
            await mediator.Send(value);
        }

  
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteIncomeRequest()
            {
                Id = id
            });
        }
    }
}
