using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class Candidate
    {
        [Key]
        public int Candidate_ID { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Candidate_name { get; set; }
        [StringLength(12, MinimumLength = 7)]
        public string Candidate_phone { get; set; }
        [Required]
        public string Candidate_email { get; set; }
        public string Candidate_note { get; set; }

        //public ICollection<Candidate> Candidates { get; set; }

    }
}
