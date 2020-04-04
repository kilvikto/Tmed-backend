using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Doctor
{
    public class GetDoctors
    {
        public class Query : IRequest<List<DoctorDto>> { }
        public class Handler : IRequestHandler<Query, List<DoctorDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<DoctorDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var doctors = await context.Doctors.ToListAsync();

                var doctorsDto = new List<DoctorDto>();
                foreach (var docotor in doctors)
                {
                    doctorsDto.Add(new DoctorDto { Id = docotor.Id, Email = docotor.User.Email });
                }

                return doctorsDto;
            }
        }
    }
}
