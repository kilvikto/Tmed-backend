using Application.History;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class HistoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateDisease(CreateDisease.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DiseasesDto>>> GetDiseases(string id)
        {
            return await Mediator.Send(new GetDiseasesPacient.Query { PacientId = long.Parse(id) });
        }

        [HttpGet]
        public async Task<ActionResult<List<DiseasesDto>>> GetDiseasesByToken()
        {
            return await Mediator.Send(new GetDiseasesByToken.Query ());
        }
    }
}
