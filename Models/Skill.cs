using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        [Required]
        public string SKill_Name { get; set; }

        public ICollection<Skill> Skills { get; set; }

    }
}
