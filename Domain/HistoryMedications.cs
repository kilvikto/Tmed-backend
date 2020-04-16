using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HistoryMedications
    {
        public long Id { get; set; }
        //public bool IsNowApply { get; set; }
        //public DateTime Date { get; set; }

        public virtual Medications Medications { get; set; }
        public long MedicationsId { get; set; }

        public virtual Pacient Pacient { get; set; }
        public long PacientId { get; set; }
    }
}
