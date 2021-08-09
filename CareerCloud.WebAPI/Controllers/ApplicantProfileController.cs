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
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {

            EFGenericRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }
        [HttpGet]
        [Route("profile/{ApplicantProfileId}")]
        public ActionResult GetApplicantProfile(Guid ApplicantProfileId)
        {
            ApplicantProfilePoco poco = _logic.Get(ApplicantProfileId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("profile")]
        public ActionResult GetAllApplicantProfile()
        {
            List<ApplicantProfilePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("profile")]
        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] ApplicantProfile)
        {

            _logic.Add(ApplicantProfile);
            return Ok();

        }
        [HttpDelete]
        [Route("profile")]
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] ApplicantProfile)
        {
            _logic.Delete(ApplicantProfile);
            return Ok();

        }
        [HttpPut]
        [Route("profile")]
        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] ApplicantProfile)
        {

            _logic.Update(ApplicantProfile);
            return Ok();

        }
    }
}
