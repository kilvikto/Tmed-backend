using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MedicationsHistory
{
    public class MedicationsDto
    {
        public long Id { get; set; }
        public long PacientId { get; set; }
        public string name { get; set; }
        //public bool IsNowApply { get; set; }
    }
}
