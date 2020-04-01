using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Records
    {
        public uint Id { get; set; } 
        public DateTime TimeOfReceipt { get; set; }
        public virtual User UserId { get; set; }
        public float BloodGlucose { get; set; }
        public int PressureUp { get; set; }
        public int PressureDown { get; set; }
        public int Pulse { get; set; }
        public float Temperature { get; set; }
        public bool IsIndigestion { get; set; }
        public bool IsRheum { get; set; }
        public bool IsSoreThroat { get; set; }
        public bool IsNausea { get; set; }
        public bool IsHeadache { get; set; }
    }

}

