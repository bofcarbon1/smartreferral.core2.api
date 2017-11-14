using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class SkillCategory
    {
        [Key]
        public int Skill_Category_ID { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Skill_Category_Name { get; set; }
    }
}
