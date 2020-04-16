using System;
using System.Collections.Generic;
using System.Text;

namespace Application.History
{
    public class DiseasesDto
    {
        public long Id { get; set; }
        public long PacientId { get; set; }
        public string name { get; set; }
        //public bool IsNowSick { get; set; }
    }
}
