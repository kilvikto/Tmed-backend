using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Profile
{
    public class GetPacientsProfile
    {
        public class Query : IRequest<PacientsProfileDto>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, PacientsProfileDto>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<PacientsProfileDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var pacient = await context.Pacients.SingleOrDefaultAsync(x => x.Id == request.PacientId);
                var doctorUserId = context.Doctors.SingleOrDefault(x => x.Id == pacient.DoctorId).UserId;
                var doctorEmail = context.Users.SingleOrDefault(x => x.Id == doctorUserId).Email;

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
                    Weight = pacient.Weight,
                    DoctorId = pacient.DoctorId,
                    DoctorEmail = doctorEmail
                };
            }
        }
    }
}
