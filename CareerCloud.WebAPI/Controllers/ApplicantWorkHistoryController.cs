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
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {

           EFGenericRepository<ApplicantWorkHistoryPoco> repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }
        [HttpGet]
        [Route("workhistory/{ApplicantWorkHistoryId}")]
        public ActionResult GetApplicantWorkHistory(Guid ApplicantWorkHistoryId)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(ApplicantWorkHistoryId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("workhistory")]
        public ActionResult GetAllApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("workhistory")]
        public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] ApplicantWorkHistory)
        {

            _logic.Add(ApplicantWorkHistory);
            return Ok();

        }
        [HttpDelete]
        [Route("workhistory")]
        public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] ApplicantWorkHistory)
        {

            _logic.Delete(ApplicantWorkHistory);
            return Ok();

        }
        [HttpPut]
        [Route("workhistory")]
        public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] ApplicantWorkHistory)
        {

            _logic.Update(ApplicantWorkHistory);
            return Ok();


        }
    }
}
