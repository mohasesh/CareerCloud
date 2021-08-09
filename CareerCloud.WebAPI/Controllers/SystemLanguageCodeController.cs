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
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
          EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
           
            _logic = new SystemLanguageCodeLogic(repo);
        }
        [HttpGet]
        [Route("languagecode/{LanguageId}")]

        public ActionResult GetSystemLanguageCode(string LanguageId)
        {
            SystemLanguageCodePoco poco = _logic.Get(LanguageId);
            if (poco == null)
                return NotFound();
            return Ok(poco);
        }
        [HttpGet]
        [Route("languagecode")]
        public ActionResult GetAllSystemLanguageCode()
        {

            IList<SystemLanguageCodePoco> poco = _logic.GetAll();
            if (poco == null)
                return NotFound();
            return Ok(poco);

        }
        [HttpPost]
        [Route("languagecode")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemlanguageCode)
        {

            _logic.Add(systemlanguageCode);
            return Ok();

        }
        [HttpDelete]
        [Route("languagecode")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemlanguageCode)
        {
            _logic.Delete(systemlanguageCode);
            return Ok();
        }
        [HttpPut]
        [Route("languagecode")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemlanguageCode)
        {

            _logic.Update(systemlanguageCode);
            return Ok();

        }
    }
}
