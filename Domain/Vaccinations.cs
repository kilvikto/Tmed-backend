using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Vaccinations
    {
        public long Id { get; set; }
        public string NameVaccination { get; set; }
        public virtual ICollection<HistoryVaccinations> HistoryVaccinations { get; set; }
    }
}
