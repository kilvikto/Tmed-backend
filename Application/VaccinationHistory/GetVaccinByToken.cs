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

namespace Application.VaccinationHistory
{
    public class GetVaccinByToken
    {
        public class Query : IRequest<List<VaccinationsDto>>
        {
        }
        public class Handler : IRequestHandler<Query, List<VaccinationsDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }
            public async Task<List<VaccinationsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var pacientVaccinations = await context.HistoryVaccinations.Where(x => x.PacientId == pacientId).ToListAsync();

                var vaccinationsDto = new List<VaccinationsDto>();
                foreach (var vaccin in pacientVaccinations)
                {
                    vaccinationsDto.Add(new VaccinationsDto
                    {
                        Id = vaccin.VaccinationsId,
                        NameVaccination = vaccin.Vaccinations.NameVaccination,
                        PacientId = vaccin.PacientId
                    });
                }

                return vaccinationsDto;
            }
        }
    }
}
