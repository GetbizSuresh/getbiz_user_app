using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Business_Categories;
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
    public class UserAppBusinessCategoriesController : ControllerBase
    {
        private IUserAppBusinessCategoriesRepository userAppBusinessCategoriesRepository;
        public UserAppBusinessCategoriesController(IUserAppBusinessCategoriesRepository _userAppBusinessCategoriesRepository)
        {
            userAppBusinessCategoriesRepository = _userAppBusinessCategoriesRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppBusinessCategories")]
        public IActionResult AddUserAppBusinessCategories(user_app_business_categories user_app_business_categories)
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.AddUserAppBusinessCategories(user_app_business_categories);
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
        [Route("api/EditUserAppBusinessCategories")]
        public IActionResult EditUserAppBusinessCategories(user_app_business_categories user_app_business_categories)
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.EditUserAppBusinessCategories(user_app_business_categories);
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
        [Route("api/GetALLUserAppBusinessCategories")]
        public IActionResult GetALLUserAppBusinessCategories()
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.GetALLUserAppBusinessCategories();
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

        [HttpPost]   //This is Delete Methode
        [Route("api/DeleteUserAppBusinessCategory")]

        public IActionResult DeleteUserAppBusinessCategory(string UserAppBusinessCategoryId)
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.DeleteUserAppBusinessCategory(UserAppBusinessCategoryId);
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
        [Route("api/ReAssignUserAppsBusinessCategory")]
        public IActionResult ReAssignUserAppsBusinessCategory(user_app_categories_parent1 user_app_categories_parent1)
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.ReAssignUserAppsBusinessCategory(user_app_categories_parent1);
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
        [Route("api/ReAssignUserAppsBusinessCategoryDeleteUserId")]
        public IActionResult ReAssignUserAppsBusinessCategoryDeleteUserId(user_app_categories_parent1 user_app_categories_parent1)
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.ReAssignUserAppsBusinessCategoryDeleteUserId(user_app_categories_parent1);
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
        [Route("api/GetALLUserAppsBusinessCategoryAuditTrail")]
        public IActionResult GetALLUserAppsBusinessCategoryAuditTrail()
        {
            try
            {
                var messages = userAppBusinessCategoriesRepository.GetALLUserAppsBusinessCategoryAuditTrail();
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
