﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class BasicParameters
    {
        public int IdBasicParameters { get; set; }
        public float BloodGlucose { get; set; }
        public int Pressure { get; set; }
        public float Temperature { get; set; }
        public int Pulse { get; set; }
        public virtual Records Id { get; set; }
    }
}
