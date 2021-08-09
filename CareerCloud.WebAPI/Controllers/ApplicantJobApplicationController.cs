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
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {

            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }
        [HttpGet]
        [Route("jobeducation/{ApplicantJobApplicationId}")]
        public ActionResult GetApplicantJobApplication(Guid ApplicantJobApplicationId)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(ApplicantJobApplicationId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("jobeducation")]
        public ActionResult GetAllApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("jobapplication")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }
        [HttpDelete]
        [Route("jobapplication")]
        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
        [HttpPut]
        [Route("jobapplication")]
        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }
    }
}
