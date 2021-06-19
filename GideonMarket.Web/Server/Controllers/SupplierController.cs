using GideonMarket.UseCases.Handlers.Suppliers;
using GideonMarket.UseCases.Handlers.Suppliers.Commands;
using GideonMarket.UseCases.Handlers.Suppliers.Queries;
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
    public class SupplierController : ControllerBase
    {
        private readonly IMediator mediator;
        public SupplierController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IEnumerable<SupplierDto>> Get()
        {
            return await mediator.Send(new GetAllSupplierRequest());
        }

        // GET api/<SupplierController>/5
        //[HttpGet("{id}")]
        //public async Task<SupplierDto> Get(int id)
        //{
        //    return await mediator.Send(new GetSupplierRequest() { Id = id });
        //}

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<int> Post([FromBody] SupplierDto value)
        {
           return  await mediator.Send(new CreateSupplierRequest() { dto = value });
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SupplierDto value)
        {
            await mediator.Send(new UpdateSupplierRequest() { dto = value });
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteSupplierRequest() { Id = id });
        }
    }
}
