﻿using Application.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProfileController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(Update.Command command)
        {
            return await Mediator.Send(command);
        }


        [HttpGet]
        public async Task<ActionResult<PacientsProfileDto>> GetProfile()
        {
            return await Mediator.Send(new GetPacientProfilebyToken.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacientsProfileDto>> Get(string id)
        {
            return await Mediator.Send(new GetPacientsProfile.Query { PacientId = long.Parse(id) });
        }
    }
}
