using Application.MedicationsHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MedicationHistoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateMedication(CreateMedication.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicationsDto>>> GetMedicationById(string id)
        {
            return await Mediator.Send(new GetMedicationById.Query { PacientId = long.Parse(id) });
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicationsDto>>> MedicationsGetByToken()
        {
            return await Mediator.Send(new MedicationsGetByToken.Query());
        }
    }
}
