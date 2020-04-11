using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VaccinationHistory
{
    public class VaccinationsDto
    {
        public long Id { get; set; }
        public long PacientId { get; set; }
        public string NameVaccination { get; set; }
    }
}
