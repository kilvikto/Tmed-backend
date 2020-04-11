using Application.AllergiesHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AllergyHistoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateDisease(Create.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AllergiesDto>>> GetAllergiesById(string id)
        {
            return await Mediator.Send(new GetAllergiesById.Query { PacientId = long.Parse(id) });
        }

        [HttpGet]
        public async Task<ActionResult<List<AllergiesDto>>> GetDiseasesByToken()
        {
            return await Mediator.Send(new GetAllergiesByToken.Query());
        }
    }
}
