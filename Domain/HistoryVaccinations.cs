using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HistoryVaccinations
    {
        public long Id { get; set; }

        public virtual Pacient Pacient { get; set; }
        public long PacientId { get; set; }

        public virtual Vaccinations Vaccinations { get; set; }
        public long VaccinationsId { get; set; }
    }
}
