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
        public int ID { get; set; }
        [Required]
        public int CandidateID { get; set; }
        [Required]
        public int SkillID { get; set; }
        [Range (1, 5)]
        public int Candidate_Skill_Level { get; set; }
        [Range(1, 25)]
        public int Candidate_Skill_Years { get; set; }

        public ICollection<CandidateSkill> CandidateSkills { get; set; }

    }
}
