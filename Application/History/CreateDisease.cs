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
            public string name { get; set; }
            //public bool IsNowSick { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var historyDiseases = new HistoryDiseases
                {
                    Diseases = new Diseases
                    {
                        name = request.name
                    },
                    PacientId = pacientId,
                    //IsNowSick = request.IsNowSick,
                    //Date = DateTime.Now
                };
                context.HistoryDiseases.Add(historyDiseases);

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
   
}



