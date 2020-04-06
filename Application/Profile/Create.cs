using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Profile
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
            public string Gender { get; set; }
            public string Email { get; set; }
            public string Telefon_num { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string House_num { get; set; }
            public int Height { get; set; }
            public float Weight { get; set; }
            public string Note{ get; set; }
        }

        //public class CommandValidator : AbstractValidator<Command>
        //{
            //public CommandValidator()
            //{
                //RuleFor(x => x.Name).NotEmpty();
                //RuleFor(x => x.Surname).NotEmpty();
                //RuleFor(x => x.Birthday).NotEmpty();
                //RuleFor(x => x.Email).EmailAddress();
            //}
        //}


        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this.context = context;
                this.userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var username = userAccessor.GetUsername();
                var user = context.Users.SingleOrDefault(x => x.UserName == username);
                var pacient = new Pacient
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Birthday = request.Birthday,
                    Gender = request.Gender,
                    Email = request.Email,
                    Telefon_num = request.Telefon_num,
                    Country = request.Country,
                    Street = request.Street,
                    House_num = request.House_num,
                    Height = request.Height,
                    Weight = request.Weight,
                    Note = request.Note,
                    User = user,
                    UserId = user.Id

                };
                context.Pacients.Add(pacient);

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
