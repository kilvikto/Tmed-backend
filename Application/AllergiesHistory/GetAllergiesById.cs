using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AllergiesHistory
{
    public class GetAllergiesById
    {
        public class Query : IRequest<List<AllergiesDto>>
        {
            public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<AllergiesDto>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<List<AllergiesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pacientDiseases = await context.HistoryAllergies.Where(x => x.PacientId == request.PacientId).ToListAsync();

                var pacientDto = new List<AllergiesDto>();
                foreach (var dto in pacientDiseases)
                {
                    pacientDto.Add(new AllergiesDto
                    {
                        Id = dto.AllergiesId,
                        PacientId = dto.PacientId,
                        NameAllergy = dto.Allergies.NameAllergy,
                        IsNowSick = dto.IsNowSick
                    });
                }

                return pacientDto;
            }
        }
    }
}
