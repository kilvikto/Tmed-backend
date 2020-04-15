using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
   public class Create
    {
        public class Command : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly DataContext _dataContext;
            private readonly UserManager<User> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext dataContext, UserManager<User> userManager, IJwtGenerator jwtGenerator)
            {
                _dataContext = dataContext;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _dataContext.Users.Where(x => x.Email == request.Email).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { message = "Email already exist" });

                if (await _dataContext.Users.Where(x => x.UserName == request.Email).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { message = "UserName already exist" });

                var user = new User
                {
                    UserName = request.Email,
                    Email = request.Email,
                    Role = request.Role

                };
                var result = await _userManager.CreateAsync(user, request.Password);



                if (result.Succeeded)
                {
                    if (request.Role.ToLower() == "doctor")
                    {
                        _dataContext.Doctors.Add(new Domain.Doctor { User = user });
                    };
                    if (request.Role.ToLower() == "pacient")
                    {
                        _dataContext.Pacients.Add(new Pacient { User = user });
                    }
                    var success = await _dataContext.SaveChangesAsync(cancellationToken) > 0;

                    if (success)
                    {
                        return new UserDto
                        {
                            Token = _jwtGenerator.CreateToken(user),
                        };
                    }
                }

                throw new Exception("Problem with saving changes");
            }
        }

    }
}
