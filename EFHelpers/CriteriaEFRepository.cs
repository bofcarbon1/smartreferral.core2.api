using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReferralApiCore2.Models;
using SmartReferralApiCore2.Interfaces;

namespace SmartReferralApiCore2.EFHelpers
{
    public class CriteriaEFRepository: ICriteriaRepository
    {
        public IQueryable<Criteria> Criteria(SmartReferralContext _context, string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return _context.Criteria;
            }
            else
            {
                return _context.Criteria
                .Where(m => m.Criteria_name.Contains(filter));
            }
        }

        public Criteria Criteria(SmartReferralContext _context, int criteriaID)
        {
            return _context.Criteria.Find(criteriaID);
        }

        public string SaveCriteria(SmartReferralContext _context, Criteria criteria)
        {

            string result = "";

            try
            {
                if (criteria.Criteria_ID == 0)
                {
                    _context.Criteria.Add(criteria);
                }
                else
                {
                    Criteria dbEntry = _context.Criteria.Find(criteria.Criteria_ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Criteria_name = criteria.Criteria_name;
                        dbEntry.Criteria_pct = criteria.Criteria_pct;                      
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

        public string DeleteCriteria(SmartReferralContext _context, int criteriaID)
        {
            string result = "";
            try
            {
                Criteria dbEntry = _context.Criteria.Find(criteriaID);
                if (dbEntry != null)
                {
                    _context.Criteria.Remove(dbEntry);
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
