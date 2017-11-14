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
    //[Route("api/Skill")]
    public class SkillController : Controller
    {
        private readonly SmartReferralContext _context;

        public SkillController(SmartReferralContext context)
        {
            _context = context;
        }

        /// Get all skills via EF repository
        [Route("api/[controller]/skills")]
        [HttpGet]
        public object GetSkill(string filter)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                IQueryable<Skill> result = efcr.Skills(_context, filter)
                    .OrderBy(p => p.Skill_Name);
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

        ////Get skill by id via EF repository
        [Route("api/[controller]/skill/{id}")]
        [HttpGet]
        public IActionResult GetSkillById(int id)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                Skill result = efcr.Skill(_context, id);
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

        ////Get skills by category id via EF repository
        [Route("api/[controller]/skillsbycategory/{id}")]
        [HttpGet]
        public object GetSkillByCategoryId(int id)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                IQueryable<Skill> result = efcr.SkillByCategory(_context, id)
                     .OrderBy(p => p.Skill_Name);
                if (result == null)
                {
                    return new { StatusCode = StatusCode(201) };
                }
                return new { result = result };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { result = BadRequest() };
            }
        }

        ////Get skills available for a candidate id via EF repository
        [Route("api/[controller]/skillsavailableforcandidate/{id}")]
        [HttpGet]
        public object GetSkillsAvailableForCandidate(int id)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                IQueryable result = efcr.SkillsAvailableForCandidate(_context, id);
                     //.OrderBy(p => p.Skill_Name);
                if (result == null)
                {
                    return new { StatusCode = StatusCode(201) };
                }
                return new { result = result };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { result = BadRequest() };
            }
        }

        ////Get skill matche counts for all candidates via EF repository
        [Route("api/[controller]/skillsmatchcounts")]
        [HttpPut]
        public object GetSkillMatchCounts([FromBody]int[] skillids)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                IQueryable result = efcr.SkillsMatchCount(_context, skillids);
                if (result == null)
                {
                    return new { StatusCode = StatusCode(201) };
                }
                return new { result = result };
            }
            catch (Exception ex)
            {
                string logthis = ex.Message;
                return new { result = BadRequest() };
            }
        }

        ////Add a new skill 
        [Route("api/[controller]/addskill")]
        [HttpPut]
        public object AddSkill([FromBody]Skill skill)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                skill.Skill_ID = 0;
                string responseStatus = "";
                string result = efcr.SaveSkill(_context, skill);
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


        ////Modify a skill 
        [Route("api/[controller]/updskill/{id}")]
        [HttpPost]
        public object UpdateSkill(int id, [FromBody]Skill skill)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                skill.Skill_ID = id;
                string responseStatus = "";
                string result = efcr.SaveSkill(_context, skill);
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


        ////Delete a skill
        [Route("api/[controller]/delskill/{id}")]
        [HttpDelete]
        public object DeleteSkill(int id)
        {
            try
            {
                SkillEFRepository efcr = new SkillEFRepository();
                string responseStatus = "";
                string result = efcr.DeleteSkill(_context, id);
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

        /// Get all skill categoriess via EF repository
        [Route("api/[controller]/categories")]
        [HttpGet]
        public object GetCategory(string filter)
        {
            try
            {
                SkillCategoryEFRepository efcr = new SkillCategoryEFRepository();
                IQueryable<SkillCategory> result = efcr.SkillCategories(_context, filter)
                    .OrderBy(p => p.Skill_Category_Name);
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

        ////Get skill category by id via EF repository
        [Route("api/[controller]/category/{id}")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                SkillCategoryEFRepository efcr = new SkillCategoryEFRepository();
                SkillCategory result = efcr.SkillCategory(_context, id);
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

        ////Add a new skill category
        [Route("api/[controller]/addcategory")]
        [HttpPut]
        public object AddCategory([FromBody]SkillCategory skillcategory)
        {
            try
            {
                SkillCategoryEFRepository efcr = new SkillCategoryEFRepository();
                skillcategory.Skill_Category_ID = 0;
                string responseStatus = "";
                string result = efcr.SaveSkillCategory(_context, skillcategory);
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


        ////Modify a skill category
        [Route("api/[controller]/updcategory/{id}")]
        [HttpPost]
        public object UpdateCategory(int id, [FromBody]SkillCategory skillcategory)
        {
            try
            {
                SkillCategoryEFRepository efcr = new SkillCategoryEFRepository();
                skillcategory.Skill_Category_ID = id;
                string responseStatus = "";
                string result = efcr.SaveSkillCategory(_context, skillcategory);
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


        ////Delete a skillcategory
        [Route("api/[controller]/delcategory/{id}")]
        [HttpDelete]
        public object DeleteCategory(int id)
        {
            try
            {
                SkillCategoryEFRepository efcr = new SkillCategoryEFRepository();
                string responseStatus = "";
                string result = efcr.DeleteSkillCategory(_context, id);
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