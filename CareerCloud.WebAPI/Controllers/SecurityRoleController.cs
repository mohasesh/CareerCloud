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
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;
        public SecurityRoleController()
        {

            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            
            _logic = new SecurityRoleLogic(repo);
        }
        [HttpGet]
        [Route("role/{SecurityRoleId}")]
        public ActionResult GetSecurityRole(Guid SecurityRoleId)
        {
            SecurityRolePoco poco = _logic.Get(SecurityRoleId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("role")]
        public ActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("role")]
        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] securityRole)
        {

            _logic.Add(securityRole);
            return Ok();

        }
        [HttpDelete]
        [Route("role")]
        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] securityRole)
        {

            _logic.Delete(securityRole);
            return Ok();

        }
        [HttpPut]
        [Route("role")]
        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] securityRole)
        {

            _logic.Update(securityRole);
            return Ok();

        }
    }
}
