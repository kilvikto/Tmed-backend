using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Medications
    {
        public long Id { get; set; }
        public string NameMedication { get; set; }
        public virtual ICollection<HistoryMedications> HistoryMedications { get; set; }
    }
}
