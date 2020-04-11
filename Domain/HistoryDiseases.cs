using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HistoryDiseases
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsNowSick { get; set; }

        public virtual Diseases Diseases { get; set; }
        public long DiseasesId { get; set; }

        public virtual Pacient Pacient { get; set; }
        public long PacientId { get; set; }
    }
}
