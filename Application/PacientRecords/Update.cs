using Application.Interfaces;
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
    public class Update
    {
        public class Command : IRequest
        {
            public DateTime TimeOfReceipt { get; set; }
            public float? BloodGlucose { get; set; }
            public int? PressureUp { get; set; }
            public int? PressureDown { get; set; }
            public int? Pulse { get; set; }
            public float? Temperature { get; set; }
            public bool? IsIndigestion { get; set; }
            public bool? IsRheum { get; set; }
            public bool? IsSoreThroat { get; set; }
            public bool? IsNausea { get; set; }
            public bool? IsHeadache { get; set; }
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
                var record = context.Records.SingleOrDefault(x => x.TimeOfReceipt == request.TimeOfReceipt && x.PacientId == pacientId);

                record.BloodGlucose = request.BloodGlucose ?? record.BloodGlucose;
                record.PressureUp = request.PressureUp ?? record.PressureUp;
                record.PressureDown = request.PressureDown ?? record.PressureDown;
                record.Pulse = request.Pulse ?? record.Pulse;
                record.Temperature = request.Temperature ?? record.Temperature;
                record.IsIndigestion = request.IsIndigestion ?? record.IsIndigestion;
                record.IsRheum = request.IsRheum ?? record.IsRheum;
                record.IsSoreThroat = request.IsSoreThroat ?? record.IsSoreThroat;
                record.IsNausea = request.IsNausea ?? record.IsNausea;
                record.IsHeadache = request.IsHeadache ?? record.IsHeadache;

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}

