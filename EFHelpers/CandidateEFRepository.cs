using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.Interfaces;

namespace SmartReferralApiCore2.EFHelpers
{
    public class CandidateEFRepository: ICandidateRepository
    {
        public IQueryable<Candidate> Candidates(SmartReferralContext _context, string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return _context.Candidates;
            }
            else
            {
                return _context.Candidates
                .Where(m => m.Candidate_name.Contains(filter));
            }
        }

        public Candidate Candidate(SmartReferralContext _context, int candidateID)
        {
            return _context.Candidates.Find(candidateID);
        }


        public string SaveCandidate(SmartReferralContext _context, Candidate candidate)
        {

            string result = "";

            try
            {
                if (candidate.Candidate_ID == 0)
                {
                    _context.Candidates.Add(candidate);
                }
                else
                {
                    Candidate dbEntry = _context.Candidates.Find(candidate.Candidate_ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Candidate_name = candidate.Candidate_name;
                        dbEntry.Candidate_note = candidate.Candidate_note;
                        dbEntry.Candidate_phone = candidate.Candidate_phone;
                        dbEntry.Candidate_email = candidate.Candidate_email;                      
                    }
                }
                _context.SaveChanges();
                result = "OK";
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public string DeleteCandidate(SmartReferralContext _context, int candidateID)
        {
            string result = "";
            try
            {
                Candidate dbEntry = _context.Candidates.Find(candidateID);
                if (dbEntry != null)
                {
                    _context.Candidates.Remove(dbEntry);
                    _context.SaveChanges();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

    }

}
