using Application.Errors;
using Application.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController
    {   
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Create(Create.Command req)
        {
            return await Mediator.Send(req);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(Login.Command req)
        {
            return await Mediator.Send(req);
        }

    }
}
