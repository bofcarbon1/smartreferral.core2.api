using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.EFHelpers;

namespace SmartReferralApiCore2.Interfaces
{
    public interface ICandidateRepository
    {
        IQueryable<Candidate> Candidates(SmartReferralContext _context, string filter);
        string SaveCandidate(SmartReferralContext _context, Candidate candidate);
        string DeleteCandidate(SmartReferralContext _context, int candidateID);

        IQueryable CandidateSkills(SmartReferralContext _context, string filter, int id);
        string SaveCandidateSkill(SmartReferralContext _context, CandidateSkill candidateskill);
        string AddCandidateSkills(SmartReferralContext _context, int id, int[] newSkills);
        string DeleteCandidateSkill(SmartReferralContext _context, int candidateSkillID);
    }
}
