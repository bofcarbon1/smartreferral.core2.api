using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.Interfaces;

namespace SmartReferralApiCore2.EFHelpers
{
    public class SkillCategoryEFRepository: ISkillCategoryRepository
    {
        public IQueryable<SkillCategory> SkillCategories(SmartReferralContext _context, string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return _context.SkillCategories;
            }
            else
            {
                return _context.SkillCategories
                .Where(m => m.Skill_Category_Name.Contains(filter));
            }
        }

        public SkillCategory SkillCategory(SmartReferralContext _context, int skillcategoryID)
        {
            return _context.SkillCategories.Find(skillcategoryID);
        }

        public string SaveSkillCategory(SmartReferralContext _context, SkillCategory skillcategory)
        {

            string result = "";

            try
            {
                if (skillcategory.Skill_Category_ID == 0)
                {
                    _context.SkillCategories.Add(skillcategory);
                }
                else
                {
                    SkillCategory dbEntry = _context.SkillCategories.Find(skillcategory.Skill_Category_ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Skill_Category_Name = skillcategory.Skill_Category_Name;
                       
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


        public string DeleteSkillCategory(SmartReferralContext _context, int skillcategoryID)
        {
            string result = "";
            try
            {
                SkillCategory dbEntry = _context.SkillCategories.Find(skillcategoryID);
                if (dbEntry != null)
                {
                    _context.SkillCategories.Remove(dbEntry);
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
