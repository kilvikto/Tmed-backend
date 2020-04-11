using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MedicationsHistory
{
    public class GetMedicationById
    {
        public class Query : IRequest<List<MedicationsDto>>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<MedicationsDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<MedicationsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pacientMedications = await context.HistoryMedications.Where(x => x.PacientId == request.PacientId).ToListAsync();

                var pacientDto = new List<MedicationsDto>();
                foreach (var dto in pacientMedications)
                {
                    pacientDto.Add(new MedicationsDto
                    {
                        Id = dto.MedicationsId,
                        PacientId = dto.PacientId,
                        NameMedication = dto.Medications.NameMedication,
                        IsNowApply = dto.IsNowApply
                    });
                }

                return pacientDto;
            }
        }
    }
}
