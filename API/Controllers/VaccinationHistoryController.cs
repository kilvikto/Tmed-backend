using Application.VaccinationHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class VaccinationHistoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateVaccin(CreateVaccin.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<VaccinationsDto>>> GetVaccinById(string id)
        {
            return await Mediator.Send(new GetVaccinById.Query { PacientId = long.Parse(id) });
        }

        [HttpGet]
        public async Task<ActionResult<List<VaccinationsDto>>> GetVaccinByToken()
        {
            return await Mediator.Send(new GetVaccinByToken.Query());
        }
    }
}
