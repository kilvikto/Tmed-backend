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
    }
}
