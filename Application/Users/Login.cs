using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
    public class Login
    {
        public class Command : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

       // public class CommandValidator : AbstractValidator<Command>
        //{
            //public CommandValidator()
            //{
                //RuleFor(x => x.Password).Password();
                //RuleFor(x => x.Email).EmailAddress();
            //}
        //}

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                    throw new RestException(HttpStatusCode.Unauthorized);

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if(result.Succeeded)
                {
                    return new UserDto
                    {
                        Role = user.Role,
                        Email = user.Email,
                        Username = user.UserName,
                        //UserName = user.UserName,
                        Token = _jwtGenerator.CreateToken(user)
                    };
                }
                throw new RestException(HttpStatusCode.Unauthorized);

            }
        }
    }
}
