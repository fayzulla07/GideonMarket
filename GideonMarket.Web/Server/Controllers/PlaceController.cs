using GideonMarket.UseCases.Handlers.Places;
using GideonMarket.UseCases.Handlers.Places.Commands;
using GideonMarket.UseCases.Handlers.Places.Queries;
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
    public class PlaceController : ControllerBase
    {
        private readonly IMediator mediator;
        public PlaceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<PlaceController>
        [HttpGet]
        public async Task<IEnumerable<PlaceDto>> Get()
        {
            return await mediator.Send(new GetAllPlaceRequest());
        }

        //GET api/<PlaceController>/5
        //[HttpGet("{id}")]
        //public async Task<PlaceDto> Get(int id)
        //{
        //    return await mediator.Send(new GetPlaceRequest() { Id = id });
        //}

        // POST api/<PlaceController>
        [HttpPost]
        public async Task<int> Post([FromBody] CreatePlaceRequest value)
        {
            return await mediator.Send(value);
        }

        // PUT api/<PlaceController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PlaceDto value)
        {
            await mediator.Send(value);
        }

        // DELETE api/<PlaceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeletePlaceRequest() { Id = id });
        }
    }
}
