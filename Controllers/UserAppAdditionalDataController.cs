using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Additional_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppAdditionalDataController : ControllerBase
    {
        private IUserAppAdditionalDataRepository userAppAdditionalDataRepository;
        public UserAppAdditionalDataController(IUserAppAdditionalDataRepository _userAppAdditionalDataRepository)
        {
            userAppAdditionalDataRepository = _userAppAdditionalDataRepository;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppAdditionalData")]
        public IActionResult AddUserAppAdditionalData(user_app_additional_data user_app_additional_data)
        {
            try
            {
                var messages = userAppAdditionalDataRepository.AddUserAppAdditionalData(user_app_additional_data);
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
        [Route("api/EditUserAppAdditionalData")]
        public IActionResult EditUserAppAdditionalData(user_app_additional_data user_app_additional_data)
        {
            try
            {
                var messages = userAppAdditionalDataRepository.EditUserAppAdditionalData(user_app_additional_data);
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
        [Route("api/GetALLUserAppAdditionalData")]
        public IActionResult GetALLUserAppAdditionalData()
        {
            try
            {
                var messages = userAppAdditionalDataRepository.GetALLUserAppAdditionalData();
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
        [Route("api/GetALLUserAppAdditionalDataById")]
        public IActionResult GetALLUserAppAdditionalDataById(int user_app_id)
        {
            try
            {
                var messages = userAppAdditionalDataRepository.GetALLUserAppAdditionalDataById(user_app_id);
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
