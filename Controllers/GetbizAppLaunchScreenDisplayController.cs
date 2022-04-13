using getbiz_user_app.Models;
using getbiz_user_app.Repository.Getbiz_App_Launch_Screen_Display;
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
    public class GetbizAppLaunchScreenDisplayController : ControllerBase
    {

        private IGetbizAppLaunchScreenDisplayRepository getbizAppLaunchScreenDisplayRepository;
        public GetbizAppLaunchScreenDisplayController(IGetbizAppLaunchScreenDisplayRepository _getbizAppLaunchScreenDisplayRepository)
        {
            getbizAppLaunchScreenDisplayRepository = _getbizAppLaunchScreenDisplayRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddGetbizAppLaunchScreenDisplay")]
        public IActionResult AddGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display)
        {
            try
            {
                var messages = getbizAppLaunchScreenDisplayRepository.AddGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display);
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

        [AllowAnonymous]
        [HttpPost]
        [Route("api/EditGetbizAppLaunchScreenDisplay")]
        public IActionResult EditGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display)
        {
            try
            {
                var messages = getbizAppLaunchScreenDisplayRepository.EditGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display);
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


        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLGetbizAppLaunchScreenDisplay")]
        public IActionResult GetALLGetbizAppLaunchScreenDisplay()
        {
            try
            {
                var messages = getbizAppLaunchScreenDisplayRepository.GetALLGetbizAppLaunchScreenDisplay();
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

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLGetbizAppLaunchScreenDisplayById")]
        public IActionResult GetALLGetbizAppLaunchScreenDisplayById(int user_app_id)
        {
            try
            {
                var messages = getbizAppLaunchScreenDisplayRepository.GetALLGetbizAppLaunchScreenDisplayById(user_app_id);
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

