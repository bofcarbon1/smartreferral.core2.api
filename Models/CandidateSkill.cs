using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class CandidateSkill
    {
        [Key]
        public int Candidate_Skill_ID { get; set; }
        [Required]
        public int Candidate_ID { get; set; }
        [Required]
        public int Skill_ID { get; set; }
        [Range (1, 5)]
        public int Level { get; set; }
        [Range(1, 25)]
        public int Years_Used { get; set; }
        public string Last_Year_Used { get; set; }
        
    }
}
