using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HealthComplaint
    {
        public int Id { get; set; }
        public bool IsIndigestion { get; set; }
        public bool IsRheum { get; set; }
        public bool IsSoreThroat { get; set; }
        public bool IsNausea { get; set; }
        public bool IsHeadache { get; set; }
    }
}
