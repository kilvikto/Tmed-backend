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

namespace Application.AllergiesHistory
{
    public class GetAllergiesByToken
    {
        public class Query : IRequest<List<AllergiesDto>>
        {
        }
        public class Handler : IRequestHandler<Query, List<AllergiesDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }
            public async Task<List<AllergiesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacientId = context.Pacients.SingleOrDefault(x => x.UserId == userId).Id;
                var pacientDiseases = await context.HistoryAllergies.Where(x => x.PacientId == pacientId).ToListAsync();

                var allergiesDto = new List<AllergiesDto>();
                foreach (var allergy in pacientDiseases)
                {
                    allergiesDto.Add(new AllergiesDto
                    {
                        Id = allergy.AllergiesId,
                        PacientId = allergy.PacientId,
                        name = allergy.Allergies.name,
                        //IsNowSick = allergy.IsNowSick
                    });
                }

                return allergiesDto;
            }
        }
    }
}
