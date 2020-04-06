using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
    public class GetUser
    {
        public class Query : IRequest<UserDto>
        {
        }
        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserManager<User> _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<User> context, IUserAccessor userAccessor, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userAccessor = userAccessor;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {

                var user = await _context.FindByNameAsync(_userAccessor.GetUsername());
                return new UserDto
                {
                    //Email = user.Email,
                    //Role = user.Role,
                    Token = _jwtGenerator.CreateToken(user),
                    //Username = user.UserName
                };
            }
        }
    }
}
