using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartReferralApiCore2.EFHelpers;
using SmartReferralApiCore2.Models;

namespace SmartReferralApiCore2.Controllers
{
    [Produces("application/json")]
    //[Route("api/Criteria")]
    public class CriteriaController : Controller
    {
        private readonly SmartReferralContext _context;

        public CriteriaController(SmartReferralContext context)
        {
            _context = context;
        }

        /// Get all criteria
        [Route("api/[controller]/criteria")]
        [HttpGet]
        public object Get(string filter)
        {
            //Call the Criteria method of the CriteriaEFRepository to access
            //criteria data via entity framework Core2 and the database context
            try
            {
                CriteriaEFRepository efcr = new CriteriaEFRepository();
                IQueryable<Criteria> result = efcr.Criteria(_context, filter)
                    .OrderBy(p => p.Criteria_name);
                if (result == null)
                {
                    return new { StatusCode = StatusCode(201) };
                }
                return new { result = result };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { StatusCode = StatusCode(500), ErrorMsg = ex.Message };
            }

        }

        ////Get criteria by id
        [Route("api/[controller]/criteria/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            //Call the Criteria method of the CriteriaEFRepository to access
            //criteria data via entity framework Core2 and the database context
            try
            {
                CriteriaEFRepository efcr = new CriteriaEFRepository();
                Criteria result = efcr.Criteria(_context, id);
                if (result == null)
                {
                    return new ObjectResult(StatusCode(201));
                }
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new ObjectResult(ex.Message);
            }
        }

        ////Add a new criteria
        [Route("api/[controller]/addcriteria")]
        [HttpPut]
        public object Add([FromBody]Criteria criteria)
        {
            try
            {
                CriteriaEFRepository efcr = new CriteriaEFRepository();
                criteria.Criteria_ID = 0;
                string responseStatus = "";
                string result = efcr.SaveCriteria(_context, criteria);
                switch (result)
                {
                    case null:
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "":
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "OK":
                        {
                            responseStatus = "201";
                            break;
                        }
                }
                return new { responseStatus = responseStatus };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new ObjectResult(ex.Message);
            }
        }

        ////Modify criteria
        [Route("api/[controller]/updcriteria/{id}")]
        [HttpPost]
        public object Update(int id, [FromBody]Criteria criteria)
        {
            try
            {
                CriteriaEFRepository efcr = new CriteriaEFRepository();
                criteria.Criteria_ID = id;
                string responseStatus = "";
                string result = efcr.SaveCriteria(_context, criteria);
                switch (result)
                {
                    case null:
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "":
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "OK":
                        {
                            responseStatus = "200";
                            break;
                        }
                }
                return new { responseStatus = responseStatus };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { responseStatue = BadRequest() };
            }
        }

        ////Delete a criteria
        [Route("api/[controller]/delcriteria/{id}")]
        [HttpDelete]
        public object Delete(int id)
        {
            try
            {
                CriteriaEFRepository efcr = new CriteriaEFRepository();
                string responseStatus = "";
                string result = efcr.DeleteCriteria(_context, id);
                switch (result)
                {
                    case null:
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "":
                        {
                            responseStatus = "400";
                            break;
                        }
                    case "OK":
                        {
                            responseStatus = "200";
                            break;
                        }
                }
                return new { responseStatus = responseStatus };

            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { responseStatus = BadRequest() };
            }
        }

    }
}