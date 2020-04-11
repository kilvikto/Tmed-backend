using Application.Interfaces;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Profile
{
    public class GetPacientProfilebyToken
    {
        public class Query : IRequest<PacientsProfileDto>
        {
        }
        public class Handler : IRequestHandler<Query, PacientsProfileDto>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }

            public async Task<PacientsProfileDto> Handle(Query request, CancellationToken ct)
            {
                var username = userAccessor.GetUsername();
                var userId =  context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacient = context.Pacients.SingleOrDefault(x => x.UserId == userId);

                return new PacientsProfileDto
                {
                    Id = pacient.Id,
                    Name = pacient.Name,
                    Birthday = pacient.Birthday,
                    City = pacient.City,
                    Country = pacient.Country,
                    Email = pacient.Email,
                    Gender = pacient.Gender,
                    Height = pacient.Height,
                    House_num = pacient.House_num,
                    Note = pacient.Note,
                    Street = pacient.Street,
                    Surname = pacient.Surname,
                    Telefon_num = pacient.Telefon_num,
                    Weight = pacient.Weight
                };
            }

        }
    }
}
