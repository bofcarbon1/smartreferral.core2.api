using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.Interfaces;

namespace SmartReferralApiCore2.EFHelpers
{
    public class SkillEFRepository : ISKillRepository
    {
        public IQueryable<Skill> Skills(SmartReferralContext _context, string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return _context.Skills;
            }
            else
            {
                return _context.Skills
                .Where(m => m.Skill_Name.Contains(filter));
            }
        }

        public Skill Skill(SmartReferralContext _context, int skillID)
        {
            return _context.Skills.Find(skillID);
        }

        public IQueryable<Skill> SkillByCategory(SmartReferralContext _context, int skillCategoryID)
        {
            if (String.IsNullOrEmpty(skillCategoryID.ToString())
                || skillCategoryID == 0)
            {
                return _context.Skills;
            }
            else
            {
                return _context.Skills
                .Where(m => m.Skill_Category_ID.Equals(skillCategoryID));
            }
        }

        public IQueryable SkillsAvailableForCandidate(SmartReferralContext _context, int candidateID)
        {
            if (String.IsNullOrEmpty(candidateID.ToString())
                || candidateID == 0)
            {
                return _context.Skills;
            }
            else
            {
                //Join the skills and candidate skills and return
                //skills that are not in the result set of matched
                //candidate skills that match the passed candidate ID
                //We use the 'query' option to do this.

                var query = (                                   
                    from cs in _context.CandidateSkills
                    join s in _context.Skills on cs.Skill_ID equals s.Skill_ID
                    where cs.Candidate_ID.Equals(candidateID) 
                    select new
                    {
                        Skill_ID = cs.Skill_ID,
                        //Skill_Name = s.Skill_Name
                    });

                var results = from p in _context.Skills
                where !(query.Any
                                (q => q.Skill_ID == p.Skill_ID                                
                                ))
                select new { id = p.Skill_ID, name = p.Skill_Name };

                return results;                
            }
        }

        public IQueryable SkillsMatchCount(SmartReferralContext _context, 
            int[] skillids)
        {
            if (String.IsNullOrEmpty(skillids[0].ToString()))
            {
                return null;
            }
            else
            {
                //Return a a list of candidate IDs and count of skills
                //where skills match the list of skills passed to the query.
                //We use the 'query' option to do this.

                var results = (
                    from cs in _context.CandidateSkills
                    .Where(f => skillids.Contains(f.Skill_ID))
                    select new
                    {
                        Candidate_ID = cs.Candidate_ID,
                        Skill_ID = cs.Skill_ID                        
                    }
                );

                return results;
                
            }
        }

        public string SaveSkill(SmartReferralContext _context, Skill skill)
        {

            string result = "";

            try
            {
                if (skill.Skill_ID == 0)
                {
                    _context.Skills.Add(skill);
                }
                else
                {
                    Skill dbEntry = _context.Skills.Find(skill.Skill_ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Skill_Name = skill.Skill_Name;
                        dbEntry.Skill_Category_ID = skill.Skill_Category_ID;
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


        public string DeleteSkill(SmartReferralContext _context, int skillID)
        {
            string result = "";
            try
            {
                Skill dbEntry = _context.Skills.Find(skillID);
                if (dbEntry != null)
                {
                    _context.Skills.Remove(dbEntry);
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
