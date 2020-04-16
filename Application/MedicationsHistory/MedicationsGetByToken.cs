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

namespace Application.MedicationsHistory
{
    public class MedicationsGetByToken
    {
        public class Query : IRequest<List<MedicationsDto>>
        {
        }
        public class Handler : IRequestHandler<Query, List<MedicationsDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }
            public async Task<List<MedicationsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var pacientDiseases = await context.HistoryMedications.Where(x => x.PacientId == pacientId).ToListAsync();

                var medicationsDto = new List<MedicationsDto>();
                foreach (var medication in pacientDiseases)
                {
                    medicationsDto.Add(new MedicationsDto
                    {
                        Id = medication.MedicationsId,
                        PacientId = medication.PacientId,
                        name = medication.Medications.name,
                        //IsNowApply = medication.IsNowApply
                    });
                }

                return medicationsDto;
            }
        }
    }
}
