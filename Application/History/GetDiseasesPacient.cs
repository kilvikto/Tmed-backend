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
    public class GetDiseasesPacient
    {
        public class Query : IRequest<List<DiseasesDto>>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<DiseasesDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<DiseasesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pacientDiseases = await context.HistoryDiseases.Where(x => x.PacientId == request.PacientId).ToListAsync();

                var pacientDto = new List<DiseasesDto>();
                foreach(var dto in pacientDiseases)
                {
                    pacientDto.Add(new DiseasesDto
                    {
                        Id = dto.DiseasesId,
                        PacientId = dto.PacientId,
                        name = dto.Diseases.name,
                        //IsNowSick = dto.IsNowSick
                    });
                }

                return pacientDto;
            }
        }
    }
}
