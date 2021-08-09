using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }
        [HttpGet]
        [Route("jobskill/{CompanyJobSkillId}")]
        public ActionResult GetCompanyJobSkill(Guid CompanyJobSkillId)
        {
            CompanyJobSkillPoco poco = _logic.Get(CompanyJobSkillId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("jobskill")]
        public ActionResult GetAllCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("jobskill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkill)
        {

            _logic.Add(CompanyJobSkill);
            return Ok();


        }
        [HttpDelete]
        [Route("jobskill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkill)
        {

            _logic.Delete(CompanyJobSkill);
            return Ok();

        }
        [HttpPut]
        [Route("jobskill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkill)
        {

            _logic.Update(CompanyJobSkill);
            return Ok();
        }

    }
    }

