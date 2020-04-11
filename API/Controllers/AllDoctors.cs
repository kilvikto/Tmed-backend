using Application.Doctor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AllDoctors : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<DoctorDto>>> GetDoctors()
        {
            return await Mediator.Send(new GetDoctors.Query());
        }
    }
}
