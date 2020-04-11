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

namespace Application.PacientRecords
{
    public class Create
    {
        public class Command : IRequest
        {
            public DateTime TimeOfReceipt { get; set; }
            public float BloodGlucose { get; set; }
            public int PressureUp { get; set; }
            public int PressureDown { get; set; }
            public int Pulse { get; set; }
            public float Temperature { get; set; }
            public bool IsIndigestion { get; set; }
            public bool IsRheum { get; set; }
            public bool IsSoreThroat { get; set; }
            public bool IsNausea { get; set; }
            public bool IsHeadache { get; set; }
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
                var pacient = context.Pacients.SingleOrDefault(x => x.UserId == userId);
                var pacientId = pacient.Id;
                var record = new Records
                {
                    PacientId = pacientId,
                    TimeOfReceipt = request.TimeOfReceipt,
                    BloodGlucose = request.BloodGlucose,
                    PressureUp = request.PressureUp,
                    PressureDown = request.PressureDown,
                    Pulse = request.Pulse,
                    Temperature = request.Temperature,
                    IsIndigestion = request.IsIndigestion,
                    IsRheum = request.IsRheum,
                    IsSoreThroat = request.IsSoreThroat,
                    IsNausea = request.IsNausea,
                    IsHeadache = request.IsHeadache

                };
                context.Records.Add(record);

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
