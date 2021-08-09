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
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;
        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }
        [HttpGet]
        [Route("job/{CompanyJobId}")]
        public ActionResult GetCompanyJob(Guid CompanyJobId)
        {
            CompanyJobPoco poco = _logic.Get(CompanyJobId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("job")]
        public ActionResult GetAllCompanyJob()
        {
            List<CompanyJobPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpDelete]
        [Route("job")]
        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] companyJob)
        {

            _logic.Delete(companyJob);
            return Ok();


        }
        [HttpPut]
        [Route("job")]
        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] companyJob)
        {

            _logic.Update(companyJob);
            return Ok();

        }
        [HttpPost]
        [Route("job")]
        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] companyJobs)
        {

            _logic.Add(companyJobs);
            return Ok();

        }
    }
}
