using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppCommunicationController : ControllerBase
    {
        private IUserAppCommunicationRepository userAppCommunicationRepository;

        public UserAppCommunicationController(IUserAppCommunicationRepository _userAppCommunicationRepository)
        {
            userAppCommunicationRepository = _userAppCommunicationRepository;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveCommunicationData")]
        public IActionResult SaveCommunicationData(user_app_communication user_app_communication)
        {
            try
            {
                var messages = userAppCommunicationRepository.SaveCommunicationData(user_app_communication);
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
        [Route("api/DeleteCommunicationData")]
        public IActionResult DeleteCommunicationData(int user_app_id)
        {
            try
            {
                var messages = userAppCommunicationRepository.DeleteCommunicationData(user_app_id);
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
        [Route("api/DeleteCommunicationDataById")]
        public IActionResult DeleteCommunicationDataById(int user_Id, int communication_ID)
        {
            try
            {
                var messages = userAppCommunicationRepository.DeleteCommunicationDataById(user_Id, communication_ID);
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
        [Route("api/UpdateCommunicationData")]
        public IActionResult UpdateCommunicationData(user_app_communication user_app_communication)
        {
            try
            {
                var messages = userAppCommunicationRepository.UpdateCommunicationData(user_app_communication);
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

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("api/GetAllCommunicationDataById")]
        //public IActionResult GetAllCommunicationDataById(int CommunicationId, int user_app_id)
        //{
        //    try
        //    {
        //        var messages = userAppCommunicationRepository.GetAllCommunicationDataById(CommunicationId, user_app_id);
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
        [Route("api/GetAllCommunicationData")]
        public IActionResult GetAllCommunicationData(int user_app_id)
        {
            try
            {
                var messages = userAppCommunicationRepository.GetAllCommunicationData(user_app_id);
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
