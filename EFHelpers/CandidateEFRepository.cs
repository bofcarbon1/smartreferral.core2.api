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
        // Candidate

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
                        dbEntry.Candidate_screen_level = candidate.Candidate_screen_level;
                        dbEntry.Candidate_video_level = candidate.Candidate_video_level;
                        dbEntry.Candidate_code_sample_level = candidate.Candidate_code_sample_level;
                        dbEntry.Candidate_skill_level = candidate.Candidate_skill_level;
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

        //Candidate Skills

        public IQueryable CandidateSkills(SmartReferralContext _context, 
            string filter, int id)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return _context.CandidateSkills;
            }
            else
            {
                if (filter.Equals("Candidate")) {
                    var query = (from cs in _context.CandidateSkills
                                join s in _context.Skills on cs.Skill_ID equals s.Skill_ID
                                where cs.Candidate_ID.Equals(id)
                                select new 
                                {
                                    Candidate_ID = cs.Candidate_ID,
                                    Candidate_Skill_ID = cs.Candidate_Skill_ID,
                                    Last_Year_Used = cs.Last_Year_Used,
                                    Years_Used = cs.Years_Used,
                                    Skill_ID = cs.Skill_ID,
                                    Level = cs.Level,
                                    Skill_Name = s.Skill_Name
                                });

                    return (IQueryable)query;    
                }
                else
                {
                    if (filter.Equals("Skill"))
                    {
                        var query = (from cs in _context.CandidateSkills
                                     join s in _context.Skills on cs.Skill_ID equals s.Skill_ID
                                     where cs.Skill_ID.Equals(id)
                                     select new
                                     {
                                         Candidate_ID = cs.Candidate_ID,
                                         Candidate_Skill_ID = cs.Candidate_Skill_ID,
                                         Last_Year_Used = cs.Last_Year_Used,
                                         Years_Used = cs.Years_Used,
                                         Skill_ID = cs.Skill_ID,
                                         Level = cs.Level,
                                         Skill_Name = s.Skill_Name
                                     });

                        return (IQueryable)query;
                    }
                    else
                    {
                        return _context.CandidateSkills;
                    }                   
                }                
            }
        }

        public CandidateSkill CandidateSkill(SmartReferralContext _context, 
            int candidateSkillID)
        {
            return _context.CandidateSkills.Find(candidateSkillID);
        }


        public string SaveCandidateSkill(SmartReferralContext _context, 
            CandidateSkill candidateSkill)
        {

            string result = "";

            try
            {
                if (candidateSkill.Candidate_Skill_ID == 0)
                {
                    _context.CandidateSkills.Add(candidateSkill);
                }
                else
                {
                    CandidateSkill dbEntry = _context.CandidateSkills
                        .Find(candidateSkill.Candidate_Skill_ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Level = candidateSkill.Level;
                        dbEntry.Years_Used = candidateSkill.Years_Used;
                        dbEntry.Last_Year_Used = candidateSkill.Last_Year_Used;                        
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


        public string AddCandidateSkills(SmartReferralContext _context,
            int id, int[] newSkills)
        {

            string result = "";

            try
            {
                for (int i = 0; i < newSkills.Length; i++)
                {
                    CandidateSkill candidateSkill = new Models.CandidateSkill();
                    candidateSkill.Candidate_ID = id;
                    candidateSkill.Skill_ID = newSkills[i];
                    candidateSkill.Level = 3;
                    candidateSkill.Years_Used = 1;
                    candidateSkill.Last_Year_Used = "2017";
                    _context.CandidateSkills.Add(candidateSkill);
                    _context.SaveChanges();
                }              
                result = "OK";
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public string DeleteCandidateSkill(SmartReferralContext _context, 
            int candidateSkillID)
        {
            string result = "";
            try
            {
                CandidateSkill dbEntry = _context.CandidateSkills.Find(candidateSkillID);
                if (dbEntry != null)
                {
                    _context.CandidateSkills.Remove(dbEntry);
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
