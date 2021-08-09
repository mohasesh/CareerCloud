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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
           
            _logic = new CompanyJobDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("jobdescription/{CompanyDescriptionId}")]
        public ActionResult GetCompanyJobsDescription(Guid CompanyDescriptionId)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(CompanyDescriptionId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("jobdescription")]
        public ActionResult GetAllCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpDelete]
        [Route("jobdescription/")]
        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescription)
        {

            _logic.Delete(companyJobDescription);
            return Ok();

        }
        [HttpPut]
        [Route("jobdescription")]
        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescription)
        {

            _logic.Update(companyJobDescription);
            return Ok();

        }
        [HttpPost]
        [Route("jobdescription")]
        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescription)
        {

            _logic.Add(companyJobDescription);
            return Ok();

        }
    }
}
