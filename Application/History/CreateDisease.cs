using Application.Interfaces;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.History
{
    public class CreateDisease
    {
        public class Command : IRequest
        {
            public string NameDisease { get; set; }
            public bool IsNowSick { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccesor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccesor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var username = userAccesor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var historyDiseases = new HistoryDiseases
                {
                    Diseases = new Diseases
                    {
                        NameDisease = request.NameDisease
                    },
                    PacientId = pacientId,
                    IsNowSick = request.IsNowSick,
                    Date = DateTime.Now
                };
                context.HistoryDiseases.Add(historyDiseases);

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
   
}



