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

namespace Application.History
{
    public class GetDiseasesByToken
    {
        public class Query : IRequest<List<DiseasesDto>>
        {
            //public long PacientId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<DiseasesDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }
            public async Task<List<DiseasesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var pacientDiseases = await context.HistoryDiseases.Where(x => x.PacientId == pacientId).ToListAsync();

                var pacientDto = new List<DiseasesDto>();
                foreach (var dto in pacientDiseases)
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
