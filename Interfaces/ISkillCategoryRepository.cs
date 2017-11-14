using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.EFHelpers;

namespace SmartReferralApiCore2.Interfaces
{
    public interface ISkillCategoryRepository
    {
        IQueryable<SkillCategory> SkillCategories(SmartReferralContext _context, string filter);
        string SaveSkillCategory(SmartReferralContext _context, SkillCategory skillcategory);
        string DeleteSkillCategory(SmartReferralContext _context, int skillcategoryID);
    }
}
