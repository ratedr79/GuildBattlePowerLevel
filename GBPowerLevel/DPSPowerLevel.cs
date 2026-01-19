using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GBPowerLevel
{
    public class DPSPowerLevel
    {
        [Required]
        public string Character { get; set; }
        public double PowerLevel { get; set; }
    }
}
