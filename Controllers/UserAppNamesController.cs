using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Names;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    //[ApiController]
    //public class UserAppNamesController : ControllerBase
    //{
    //    private IUserAppNamesRepository userAppNamesRepository;
    //    public UserAppNamesController(IUserAppNamesRepository _userAppNamesRepository)
    //    {
    //        userAppNamesRepository = _userAppNamesRepository;
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    [Route("api/AddUserAppNames")]
    //    public IActionResult AddUserAppNames(user_app_names user_app_names_Model)
    //    {
    //        try
    //        {
    //            var messages = userAppNamesRepository.AddUserAppNames(user_app_names_Model);
    //            if (messages == null)
    //            {
    //                return NotFound();
    //            }

    //            return Ok(messages);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest();
    //        }
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    [Route("api/EditUserAppNames")]
    //    public IActionResult EditUserAppNames(user_app_names user_app_names_Model)
    //    {
    //        try
    //        {
    //            var messages = userAppNamesRepository.EditUserAppNames(user_app_names_Model);
    //            if (messages == null)
    //            {
    //                return NotFound();
    //            }

    //            return Ok(messages);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest();
    //        }
    //    }


    //    [AllowAnonymous]
    //    [HttpGet]
    //    [Route("api/GetALLUserAppNames")]
    //    public IActionResult GetALLUserAppNames()
    //    {
    //        try
    //        {
    //            var messages = userAppNamesRepository.GetALLUserAppNames();
    //            if (messages == null)
    //            {
    //                return NotFound();
    //            }

    //            return Ok(messages);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest();
    //        }
    //    }

    //}
}
 
