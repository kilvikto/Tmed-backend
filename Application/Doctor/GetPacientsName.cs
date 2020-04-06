using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Doctor
{
    public class GetPacientsName
    {
        public class Query : IRequest<List<PacientsNameDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<PacientsNameDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<PacientsNameDto>> Handle(Query request, CancellationToken ct)
            {
                var pacients = await context.Pacients.Where(x => x.DoctorId == request.Id).ToListAsync(ct);

                var pacientsNames = new List<PacientsNameDto>();
                foreach (var pacient in pacients)
                {
                    pacientsNames.Add(new PacientsNameDto { Id = pacient.Id, Name = pacient.Name, Email = pacient.Email });
                }

                return pacientsNames;
            }
        }
    }
}
