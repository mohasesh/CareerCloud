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
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {

            EFGenericRepository<SecurityLoginsRolePoco> repo = new EFGenericRepository<SecurityLoginsRolePoco>();
          
            _logic = new SecurityLoginsRoleLogic(repo);
        }
        [HttpGet]
        [Route("loginrole/{SecurityLoginId}")]
        public ActionResult GetSecurityLoginsRole(Guid SecurityLoginsRoleId)
        {
            SecurityLoginsRolePoco poco = _logic.Get(SecurityLoginsRoleId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("loginrole")]
        public ActionResult GetAllSecurityLoginRole()
        {
            List<SecurityLoginsRolePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("loginrole")]
        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRole)
        {

            _logic.Add(securityLoginsRole);
            return Ok();

        }
        [HttpDelete]
        [Route("loginrole")]
        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRole)
        {

            _logic.Delete(securityLoginsRole);
            return Ok();

        }
        [HttpPut]
        [Route("loginrole")]
        public ActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRole)
        {

            _logic.Update(securityLoginsRole);
            return Ok();

        }
    }
}
