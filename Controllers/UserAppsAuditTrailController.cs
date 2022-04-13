using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_Apps_Audit_Trail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppsAuditTrailController : ControllerBase
    {
        private IUserAppsAuditTrailRepository userAppsAuditTrailRepository;
        public UserAppsAuditTrailController(IUserAppsAuditTrailRepository _userAppsAuditTrailRepository)
        {
            userAppsAuditTrailRepository = _userAppsAuditTrailRepository;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/AddUserAppsAuditTrail")]
        //public IActionResult AddUserAppsAuditTrail(user_apps_audit_trail user_Apps_Audit_Trail_Model)
        //{
        //    try
        //    {
        //        var messages = userAppsAuditTrailRepository.AddUserAppsAuditTrail(user_Apps_Audit_Trail_Model);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/EditUserAppsAuditTrail")]
        //public IActionResult EditUserAppsAuditTrail(user_apps_audit_trail user_apps_audit_trail_Model)
        //{
        //    try
        //    {
        //        var messages = userAppsAuditTrailRepository.EditUserAppsAuditTrail(user_apps_audit_trail_Model);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}


        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLUserAppsAuditTrail")]
        public IActionResult GetALLUserAppsAuditTrail()
        {
            try
            {
                var messages = userAppsAuditTrailRepository.GetALLUserAppsAuditTrail();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}


 