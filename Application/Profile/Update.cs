﻿using Application.Interfaces;
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
    public class Update
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Birthday { get; set; }
            public string Gender { get; set; }
            public string Email { get; set; }
            public string Telefon_num { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string House_num { get; set; }
            public int? Height { get; set; }
            public float? Weight { get; set; }
            public Guid? DoctorId { get; set; }
            public string Note { get; set; }
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
                var userId = context.Users.SingleOrDefault(x => x.UserName == username).Id;
                var pacient = context.Pacients.SingleOrDefault(x => x.UserId == userId);

                pacient.Name = request.Name ?? pacient.Name;
                pacient.Surname = request.Surname ?? pacient.Surname;
                pacient.Birthday = request.Birthday ?? pacient.Birthday;
                pacient.Gender = request.Gender ?? pacient.Gender;
                pacient.Email = request.Email ?? pacient.Email;
                pacient.Telefon_num = request.Telefon_num ?? pacient.Telefon_num;
                pacient.Country = request.Country ?? pacient.Country;
                pacient.City = request.City ?? pacient.City;
                pacient.Street = request.Street ?? pacient.Street;
                pacient.House_num = request.House_num ?? pacient.House_num;
                pacient.Height = request.Height ?? pacient.Height;
                pacient.Weight = request.Weight ?? pacient.Weight;
                pacient.Note = request.Note ?? pacient.Note;
                pacient.DoctorId = request.DoctorId ?? pacient.DoctorId;

                //context.Pacients.Add(pacient);

                var success = await context.SaveChangesAsync(cancellationToken) > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
