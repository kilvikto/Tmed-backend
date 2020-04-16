using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Vaccinations
    {
        public long Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<HistoryVaccinations> HistoryVaccinations { get; set; }
    }
}
