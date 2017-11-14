using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.EFHelpers;

namespace SmartReferralApiCore2.Interfaces
{
    public interface ICriteriaRepository
    {
        IQueryable<Criteria> Criteria(SmartReferralContext _context, string filter);
        string SaveCriteria(SmartReferralContext _context, Criteria criteria);
        string DeleteCriteria(SmartReferralContext _context, int criteriaID);
    }
}
