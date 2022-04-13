using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_About_Demo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppAboutDemoController : ControllerBase
    {
        private IUserAppAboutDemoRepository userAppAboutDemoRepository;
        public UserAppAboutDemoController(IUserAppAboutDemoRepository _userAppAboutDemoRepository)
        {
            userAppAboutDemoRepository = _userAppAboutDemoRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppAboutDemo")]
        public IActionResult AddUserAppAboutDemo(user_app_about_demo user_app_about_demo)
        {
            try
            {
                var messages = userAppAboutDemoRepository.AddUserAppAboutDemo(user_app_about_demo);
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
        [Route("api/EditUserAppAboutDemo")]
        public IActionResult EditUserAppAboutDemo(user_app_about_demo user_app_about_demo)
        {
            try
            {
                var messages = userAppAboutDemoRepository.EditUserAppAboutDemo(user_app_about_demo);
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
        [Route("api/GetALLUserAppAboutDemo")]
        public IActionResult GetALLUserAppAboutDemo()
        {
            try
            {
                var messages = userAppAboutDemoRepository.GetALLUserAppAboutDemo();
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
        [Route("api/GetUserAppAboutDemoById")]
        public IActionResult GetUserAppAboutDemoById(int user_app_demo_id)
        {
            try
            {
                var messages = userAppAboutDemoRepository.GetUserAppAboutDemoById(user_app_demo_id);
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
        [Route("api/DeleteuserAppAboutDemo")]
        public IActionResult DeleteuserAppAboutDemo(user_app_about_demo user_app_about_demo)
        {
            try
            {
                var messages = userAppAboutDemoRepository.DeleteuserAppAboutDemo(user_app_about_demo);
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
