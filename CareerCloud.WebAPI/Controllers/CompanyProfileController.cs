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
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileLogic _logic;
        public CompanyProfileController()
        {

            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }
        [HttpGet]
        [Route("profile/{CompanyprofileId}")]
        public ActionResult GetCompanyProfile(Guid CompanyprofileId)
        {
            CompanyProfilePoco poco = _logic.Get(CompanyprofileId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("profile")]
        public ActionResult GetAllCompanyProfile()
        {
            List<CompanyProfilePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("profile")]
        public ActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] companyProfile)
        {

            _logic.Add(companyProfile);
            return Ok();

        }
        [HttpDelete]
        [Route("profile")]
        public ActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] companyProfile)
        {

            _logic.Delete(companyProfile);
            return Ok();


        }
        [HttpPut]
        [Route("profile")]
        public ActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] companyProfile)
        {

            _logic.Update(companyProfile);
            return Ok();

        }
    }
}
