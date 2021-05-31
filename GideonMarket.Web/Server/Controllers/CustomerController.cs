using GideonMarket.UseCases.Handlers.Customers;
using GideonMarket.UseCases.Handlers.Customers.Commands;
using GideonMarket.UseCases.Handlers.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get()
        {
            return await mediator.Send(new GetAllCustomerRequest());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerDto> Get(int id)
        {
            return await mediator.Send(new GetCustomerRequest() { Id = id });
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<int> Post([FromBody] CustomerDto value)
        {
           return  await mediator.Send(new CreateCustomerRequest() { dto = value });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CustomerDto value)
        {
            await mediator.Send(new UpdateCustomerRequest() { dto = value });
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteCustomerRequest() { Id = id });
        }
    }
}
