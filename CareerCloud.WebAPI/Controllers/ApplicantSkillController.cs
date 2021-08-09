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
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
        EFGenericRepository<ApplicantSkillPoco> repo = new EFGenericRepository<ApplicantSkillPoco>();
        _logic = new ApplicantSkillLogic(repo);
        }
    [HttpGet]
    [Route("Skill/{ApplicantSkillId}")]
    public ActionResult GetApplicantSkill(Guid ApplicantSkillId)
    {
        ApplicantSkillPoco poco = _logic.Get(ApplicantSkillId);
        if (poco == null)
        {
            return NotFound();
        }
        return Ok(poco);
    }
    [HttpGet]
    [Route("Skill")]
    public ActionResult GetAllApplicantSkill()
    {
        List<ApplicantSkillPoco> poco = _logic.GetAll();
        if (poco == null)
        {
            return NotFound();
        }
        return Ok(poco);
    }
    [HttpPost]
    [Route("skill")]
    public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkill)
    {

        _logic.Add(applicantSkill);
        return Ok();

    }
    [HttpDelete]
    [Route("skill")]
    public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkill)
    {

        _logic.Delete(applicantSkill);
        return Ok();

    }
    [HttpPut]
    [Route("skill")]
    public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkill)
    {

        _logic.Update(applicantSkill);
        return Ok();
    }
}
}
