﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartReferralApiCore2.Models
{
    public class Skill
    {
        [Key]
        public int Skill_ID { get; set; }
        [Required]
        public string Skill_Name { get; set; }
        [Required]
        public int Skill_Category_ID { get; set; }
    }
}
