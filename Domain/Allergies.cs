using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Allergies
    {
        public long Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<HistoryAllergies> HistoryAllergies { get; set; }

    }
}
