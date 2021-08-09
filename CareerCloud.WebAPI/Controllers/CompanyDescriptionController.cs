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
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {

            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>();
           
            _logic = new CompanyDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("description/{CompanyDescriptionId}")]
        public ActionResult GetCompanyDescription(Guid CompanyDescriptionId)
        {
            CompanyDescriptionPoco poco = _logic.Get(CompanyDescriptionId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("description")]
        public ActionResult GetAllCompanyDescription()
        {
            List<CompanyDescriptionPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("description")]
        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {

            _logic.Add(companyDescription);
            return Ok();

        }
        [HttpDelete]
        [Route("description")]
        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {
            _logic.Delete(companyDescription);
            return Ok();
        }
        [HttpPut]
        [Route("description")]
        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {
            _logic.Update(companyDescription);
            return Ok();
        }
    }
}
