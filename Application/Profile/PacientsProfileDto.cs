using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profile
{
    public class PacientsProfileDto
    {
        public long Id { get; set; }
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
        public int Height { get; set; }
        public float Weight { get; set; }
        public string Note { get; set; }
        public Guid? DoctorId { get; set; }
        public string DoctorEmail { get; set; }
    }
}
