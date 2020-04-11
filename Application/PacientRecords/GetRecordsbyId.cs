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
    public class GetRecordsbyId
    {
        public class Query : IRequest<List<RecordsDto>>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<RecordsDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<RecordsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var records = await context.Records.Where(x => x.PacientId == request.PacientId).ToListAsync();

                var pacientsRecords = new List<RecordsDto>();
                foreach (var record in records)
                {
                    pacientsRecords.Add(new RecordsDto
                    {
                        Id = record.Id,
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
