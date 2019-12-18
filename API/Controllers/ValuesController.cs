using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using MediatR;
using Application;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public ValuesController(DataContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<Value>>> Get()
        {
            return await _mediator.Send(new List.Query());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
