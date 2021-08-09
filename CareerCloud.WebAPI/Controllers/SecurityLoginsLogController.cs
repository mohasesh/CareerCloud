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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {

            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            
            _logic = new SecurityLoginsLogLogic(repo);
        }
        [HttpGet]
        [Route("loginlog/{SecurityLoginId}")]
        public ActionResult GetSecurityLoginLog(Guid SecurityLoginId)
        {
            SecurityLoginsLogPoco poco = _logic.Get(SecurityLoginId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("loginlog")]
        public ActionResult GetAllSecurityLoginLog()
        {
            List<SecurityLoginsLogPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("loginlog")]
        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLog)
        {

            _logic.Add(securityLoginsLog);
            return Ok();

        }
        [HttpDelete]
        [Route("loginlog")]
        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLog)
        {

            _logic.Delete(securityLoginsLog);
            return Ok();

        }
        [HttpPut]
        [Route("loginlog")]
        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLog)
        {

            _logic.Update(securityLoginsLog);
            return Ok();

        }
    }
}
