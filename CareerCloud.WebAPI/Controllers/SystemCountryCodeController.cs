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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
           EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            
            _logic = new SystemCountryCodeLogic(repo);
        }
        [HttpGet]
        [Route("countrycode/{Code}")]
        public ActionResult GetSystemCountryCode(string Code)
        {
            SystemCountryCodePoco poco = _logic.Get(Code);
            if (poco == null)
                return NotFound();
            return Ok(poco);
        }
        [HttpGet]
        [Route("countrycode")]
        public ActionResult GetAllSystemCountryCode()
        {
            IList<SystemCountryCodePoco> poco = _logic.GetAll();
            if (poco == null)
                return NotFound();
            return Ok(poco);


        }
        [HttpPost]
        [Route("countrycode")]
        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCode)
        {

            _logic.Add(systemCountryCode);
            return Ok();

        }
        [HttpDelete]
        [Route("countrycode")]
        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCode)
        {

            _logic.Delete(systemCountryCode);
            return Ok();

        }
        [HttpPut]
        [Route("countrycode")]
        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCode)
        {

            _logic.Update(systemCountryCode);
            return Ok();

        }
        
    }
    
}
