using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.EFHelpers;

namespace SmartReferralApiCore2.Interfaces
{
    public interface ISKillRepository
    {
        IQueryable<Skill> Skills(SmartReferralContext _context, string filter);
        IQueryable SkillsAvailableForCandidate(SmartReferralContext _context, int candidateID);
        IQueryable SkillsMatchCount(SmartReferralContext _context, int[] skillids);
        string SaveSkill(SmartReferralContext _context, Skill skill);
        string DeleteSkill(SmartReferralContext _context, int skillID);
    }
}
