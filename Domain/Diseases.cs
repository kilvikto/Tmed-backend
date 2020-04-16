using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Diseases
    {
        public long Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<HistoryDiseases> HistoryDiseases { get; set; }
    }
}
