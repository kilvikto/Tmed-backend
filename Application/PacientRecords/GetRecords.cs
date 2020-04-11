using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PacientRecords
{
    public class GetRecords
    {
        public class Query : IRequest<List<RecordsDto>>
        {
        }
        public class Handler : IRequestHandler<Query, List<RecordsDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }

            public async Task<List<RecordsDto>> Handle(Query request, CancellationToken ct)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;

                var records = await context.Records.Where(x => x.PacientId == pacientId).ToListAsync();

                var pacientsRecords = new List<RecordsDto>();
                foreach (var record in records)
                {
                    pacientsRecords.Add(new RecordsDto
                    {   Id = record.Id,
                        PacientId = record.PacientId,
                        TimeOfReceipt = record.TimeOfReceipt,
                        BloodGlucose = record.BloodGlucose,
                        PressureUp = record.PressureUp,
                        PressureDown = record.PressureDown,
                        Pulse = record.Pulse,
                        Temperature = record.Temperature,
                        IsIndigestion = record.IsIndigestion,
                        IsRheum = record.IsRheum,
                        IsSoreThroat = record.IsSoreThroat,
                        IsNausea = record.IsNausea,
                        IsHeadache = record.IsHeadache
                    });
                }

                return pacientsRecords;
            }
        }
    }
}
