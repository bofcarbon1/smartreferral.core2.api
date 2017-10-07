using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using SmartReferralApiCore2.EFHelpers;
using SmartReferralApiCore2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace SmartReferralApiCore2.Controllers
{
      
    public class CandidateController : Controller
    {
        private readonly SmartReferralContext _context;

        public CandidateController(SmartReferralContext context)
        {
            _context = context;         
        }

        /// Get all candidates
        [Route("api/[controller]/candidates")]
        public object Get(string filter)
        {
            //Call the Condidates method of the CandidateEFRepository to access
            //candidate data via entity framework Core2 and the database context
            try
            {
                CandidateEFRepository efcr = new CandidateEFRepository();
                IQueryable<Candidate> result = efcr.Candidates(_context, filter)
                    .OrderBy(p => p.Candidate_name);
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

        ////Get candidate by id
        [Route("api/[controller]/candidate/{id}")]
        public IActionResult GetById(int id)
        {
            //Call the Condidates method of the CandidateEFRepository to access
            //candidate data via entity framework Core2 and the database context
            try
            {
                CandidateEFRepository efcr = new CandidateEFRepository();
                Candidate result = efcr.Candidate(_context, id);                    
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

        ////Add a new candidate
        [Route("api/[controller]/addcandidate")]
        public object Add([FromBody]Candidate candidate)
        {
            try
            {
                CandidateEFRepository efcr = new CandidateEFRepository();
                candidate.Candidate_ID = 0;
                string responseStatus = "";
                string result = efcr.SaveCandidate(_context, candidate);
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
                return new { responseStatus = responseStatus};
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new ObjectResult(ex.Message);
            }
        }


        ////Modify a candidate
        [Route("api/[controller]/updcandidate/{id}")]
        public object Update(int id, [FromBody]Candidate candidate)
        { 
            try
            {
                CandidateEFRepository efcr = new CandidateEFRepository();
                candidate.Candidate_ID = id;
                string responseStatus = "";
                string result = efcr.SaveCandidate(_context, candidate);
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


        ////Delete a candidate
        [Route("api/[controller]/delcandidate/{id}")]
        public object Delete(int id)
        {
            try
            {
                CandidateEFRepository efcr = new CandidateEFRepository();
                string responseStatus = "";
                string result = efcr.DeleteCandidate(_context, id);
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
                return new { responseStatus = BadRequest()};
            }
        }   
        

    }

}