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
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLoginController()
        {

            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
           
            _logic = new SecurityLoginLogic(repo);
        }
        [HttpGet]
        [Route("login/{SecurityLoginId}")]
        public ActionResult GetSecurityLogin(Guid SecurityLoginId)
        {
            SecurityLoginPoco poco = _logic.Get(SecurityLoginId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("login")]
        public ActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("login")]
        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] securityLogins)
        {

            _logic.Add(securityLogins);
            return Ok();

        }
        [HttpDelete]
        [Route("login")]
        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] securityLogins)
        {

            _logic.Delete(securityLogins);
            return Ok();

        }
        [HttpPut]
        [Route("login")]
        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] securityLogins)
        {

            _logic.Update(securityLogins);
            return Ok();

        }
    }
}
