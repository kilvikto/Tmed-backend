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
            //public string Name { get; set; }
            //public DateTime DateOfBirth { get; set; }
            //public string Surname { get; set; }
            //public string Gender { get; set; }
            //public string Address1 { get; set; }
            //public string Address2 { get; set; }
            //public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            //public string PhoneNumber { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                //RuleFor(x => x.Name).NotEmpty();
                //RuleFor(x => x.DateOfBirth).NotEmpty();
                //RuleFor(x => x.Surname).NotEmpty();
                //RuleFor(x => x.Gender).NotEmpty();
                //RuleFor(x => x.Address1).NotEmpty();
                //RuleFor(x => x.Address2).NotEmpty();
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.Email).EmailAddress();
            }
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
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exist" });
                //if (await _dataContext.Users.Where(x => x.UserName == request.UserName).AnyAsync())
                    //throw new RestException(HttpStatusCode.BadRequest, new { UserName = "UserName already exist" });
                var user = new User
                {
                    //Name = request.Name,
                    //DateOfBirth = request.DateOfBirth,
                    //Surname = request.Surname,
                    //Gender = request.Gender,
                    //Age = request.Age,
                    //Address1 = request.Address1,
                    //Address2 = request.Address2,
                    //UserName = request.UserName,
                    UserName = request.Email,
                    Email = request.Email,
                    Role = request.Role
                    //PhoneNumber = request.PhoneNumber

                };
                var result = await _userManager.CreateAsync(user, request.Password);

                if(result.Succeeded)
                {
                    return new UserDto
                    {
                        Token = _jwtGenerator.CreateToken(user),
                        Role = user.Role,
                        Email = user.Email,
                        Username = user.UserName
                        //UserName = user.UserName
                    };
                }

                throw new Exception("Problem with saving changes");
            }
        }

    }
}
