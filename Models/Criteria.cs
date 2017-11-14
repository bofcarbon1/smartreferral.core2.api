using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class Criteria
    {
        [Key]
        public int Criteria_ID { get; set; }
        public string Criteria_name { get; set; }
        public int Criteria_pct { get; set; }
    }
}
