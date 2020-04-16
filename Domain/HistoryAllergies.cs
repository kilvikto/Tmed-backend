using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HistoryAllergies
    {
        public long Id { get; set; }
        //public bool IsNowSick { get; set; }
        //public DateTime Date { get; set; }

        public virtual Allergies Allergies { get; set; }
        public long AllergiesId { get; set; }

        public virtual Pacient Pacient { get; set; }
        public long PacientId { get; set; }
    }
}
