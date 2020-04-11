using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.History
{
    public class UpdateDisease
    {
        public class Command : IRequest
        {
            public long PacientId { get; set; }
            public long DiseasesId { get; set; }
            public string NameDisease { get; set; }
            public bool? IsNowSick { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var pacientDisease = await context.HistoryDiseases.Where(x => x.PacientId == request.PacientId).ToListAsync();

                //var IdDisease = context.HistoryDiseases.SingleOrDefault(x => x.PacientId == request.PacientId).DiseasesId;
                //var NameDisease = context.Diseases.SingleOrDefault(x => x.Id == IdDisease);

                //NameDisease.NameDisease = request.NameDisease ?? NameDisease.NameDisease;
                //pacientDisease.IsNowSick = request.IsNowSick ?? pacientDisease.IsNowSick;
                

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }

    }
}
