using Application.Doctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DoctorController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PacientsNameDto>>> GetPacientsName(string id)
        {
            return await Mediator.Send(new GetPacientsName.Query { Id = Guid.Parse(id) });
        }
        [HttpGet]
        public async Task<ActionResult<List<DoctorDto>>> GetDoctors()
        {
            return await Mediator.Send(new GetDoctors.Query());
        }
    }
}
