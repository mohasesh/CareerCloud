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
    public class CompanyJobEducationController : ControllerBase
    {
        private readonly CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {

            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }
        [HttpGet]
        [Route("jobeducation/{CompanyJobEducationId}")]
        public ActionResult GetCompanyJobEducation(Guid CompanyJobEducationId)
        {
            CompanyJobEducationPoco poco = _logic.Get(CompanyJobEducationId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("jobeducation")]
        public ActionResult GetAllCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("jobeducation")]
        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducation)
        {

            _logic.Add(CompanyJobEducation);
            return Ok();

        }
        [HttpDelete]
        [Route("jobeducation")]
        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducation)
        {

            _logic.Delete(CompanyJobEducation);
            return Ok();

        }
        [HttpPut]
        [Route("jobeducation")]
        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducation)
        {

            _logic.Update(CompanyJobEducation);
            return Ok();

        }
    }
}
