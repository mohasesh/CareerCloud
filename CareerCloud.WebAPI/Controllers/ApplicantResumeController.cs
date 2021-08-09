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
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {

            EFGenericRepository<ApplicantResumePoco> repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }
        [HttpGet]
        [Route("resume/{ApplicantResumeId}")]
        public ActionResult GetApplicantResume(Guid ApplicantResumeId)
        {
            ApplicantResumePoco poco = _logic.Get(ApplicantResumeId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("resume")]
        public ActionResult GetAllApplicantResume()
        {
            List<ApplicantResumePoco> poco = _logic.GetAll();
            if (poco == null)
                return NotFound();
            return Ok(poco);
        }
        [HttpPost]
        [Route("resume")]
        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResume)
        {
            _logic.Add(ApplicantResume);
            return Ok();

        }
        [HttpDelete]
        [Route("resume")]
        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResume)
        {

            _logic.Delete(ApplicantResume);
            return Ok();
        }
        [HttpPut]
        [Route("resume")]
        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResume)
        {

            _logic.Update(ApplicantResume);
            return Ok();
        }
    }
}
