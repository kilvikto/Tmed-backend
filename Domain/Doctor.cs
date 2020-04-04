using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}
