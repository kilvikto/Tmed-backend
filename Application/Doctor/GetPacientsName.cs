using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Doctor
{
    public class GetPacientsName
    {
        public class Query : IRequest<List<PacientsNameDto>>
        {
            //public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<PacientsNameDto>>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }
            public async Task<List<PacientsNameDto>> Handle(Query request, CancellationToken ct)
            {
                var username = userAccessor.GetUsername();
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var doctorId = context.Doctors.SingleOrDefault(x => x.UserId == userId).Id;
                var pacients = await context.Pacients.Where(x => x.DoctorId == doctorId).ToListAsync(ct);

                var pacientsNames = new List<PacientsNameDto>();
                foreach (var pacient in pacients)
                {
                    pacientsNames.Add(new PacientsNameDto { Id = pacient.Id, Name = pacient.Name, Surname = pacient.Surname, Email = pacient.Email });
                }
                //var pacientDiseases = await context.HistoryDiseases.Where(x => x.PacientId == request.PacientId).ToListAsync();
                //var allPacientsDiseasesWhithSickNow  = pacientDiseases.Where(x => x.IsSickNow).ToListAsync();
                //var orderedDate = pacientDiseases.OrderedBy(x => x.Date);
                //var query = from hd in context.HistoryDiseases
                            //where hd.PacientId = request.PacientId
                            //select hd;
                //var pacientDiseases2 = query.ToListAsync();
                //var historyDiseases = new HistoryDiseases
                //{
                    //Date = request.Date,
                    //Diseases = new Diseases
                    //{
                        //NameDisease = request.NameDiseases
                    //},
                    //PacientId = request.PacientId,
                    //IsNowSick = true
                //};
                //context.HistoryDiseases.Add(historyDiseases);

                //var success = await context.SaveChangesAsync()
                return pacientsNames;
            }
        }
    }
}
