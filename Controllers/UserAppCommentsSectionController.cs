using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppCommentsSectionController : ControllerBase
    {
        private IUserAppCommentsSectionRepository userAppCommentsSectionRepository;

        public UserAppCommentsSectionController(IUserAppCommentsSectionRepository _userAppCommentsSectionRepository)
        {
            userAppCommentsSectionRepository = _userAppCommentsSectionRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveComments")]
        public IActionResult SaveComments(user_app_comment user_app_comment)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.SaveComments(user_app_comment);
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
        //[HttpDelete]

        [HttpPost]     //This is Delete Methode
        [Route("api/DeleteComment")]
        public IActionResult DeleteComment(int userID)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.DeleteComment(userID);
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
        [Route("api/DeleteCommentById")]
        public IActionResult DeleteCommentById(int comment_id, int user_Id)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.DeleteCommentById(comment_id, user_Id);
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
        [Route("api/SavePublicPrivateComment")]
        public IActionResult SavePublicPrivateComment(int userID, int is_the_comment_private)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.SavePublicPrivateComment(userID, is_the_comment_private);
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
        [Route("api/UpdateComments")]
        public IActionResult UpdateComments(user_app_comment user_app_comment)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.UpdateComments(user_app_comment);
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
        [Route("api/GetAllComments")]
        public IActionResult GetAllComments(int userID)
        {
            try
            {
                var messages = userAppCommentsSectionRepository.GetAllComments(userID);
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
