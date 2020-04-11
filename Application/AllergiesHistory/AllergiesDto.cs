using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AllergiesHistory
{
    public class AllergiesDto
    {
        public long Id { get; set; }
        public long PacientId { get; set; }
        public string NameAllergy { get; set; }
        public bool IsNowSick { get; set; }
    }
}
