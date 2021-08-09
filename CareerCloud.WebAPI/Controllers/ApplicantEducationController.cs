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
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }
        [HttpGet]
        [Route("education/{ApplicantEducationId}")]
        public ActionResult GetApplicantEducation(Guid ApplicantEducationId)
        {
            ApplicantEducationPoco poco = _logic.Get(ApplicantEducationId);
            if(poco==null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("education")]
        public ActionResult GetAllApplicantEducation()
        {
            List<ApplicantEducationPoco> poco = _logic.GetAll();
            if(poco==null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("education")]
        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }
        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
        [HttpPut]
        [Route("education")]
        public ActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }
    }
}
