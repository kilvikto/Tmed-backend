using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Diseases
    {
        public long Id { get; set; }
        public string NameDisease { get; set; }
        public virtual ICollection<HistoryDiseases> HistoryDiseases { get; set; }
    }
}
