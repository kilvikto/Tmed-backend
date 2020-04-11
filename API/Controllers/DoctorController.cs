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
        [HttpGet]
        public async Task<ActionResult<List<PacientsNameDto>>> GetPacientsName()
        {
            return await Mediator.Send(new GetPacientsName.Query ());
        }
        
    }
}
