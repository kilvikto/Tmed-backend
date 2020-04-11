using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VaccinationHistory
{
    public class GetVaccinById
    {
        public class Query : IRequest<List<VaccinationsDto>>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<VaccinationsDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<VaccinationsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pacientVaccinations = await context.HistoryVaccinations.Where(x => x.PacientId == request.PacientId).ToListAsync();

                var pacientDto = new List<VaccinationsDto>();
                foreach (var dto in pacientVaccinations)
                {
                    pacientDto.Add(new VaccinationsDto
                    {
                        Id = dto.VaccinationsId,
                        NameVaccination = dto.Vaccinations.NameVaccination,
                        PacientId = dto.PacientId
                    });
                }

                return pacientDto;
            }
        }
    }
}
