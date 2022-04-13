using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Categories;
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
    public class UserAppCategoriesController : ControllerBase
    {
        private IUserAppCategoriesRepository userAppCategoriesRepository;
        public UserAppCategoriesController(IUserAppCategoriesRepository _userAppCategoriesRepository)
        {
            userAppCategoriesRepository = _userAppCategoriesRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppCategories")]
        public IActionResult AddUserAppCategories(user_app_categories user_app_categories_Model)
        {
            try
            {
                var messages = userAppCategoriesRepository.AddUserAppCategories(user_app_categories_Model);
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
        [Route("api/AddUserAppCategoryUser")]
        public IActionResult AddUserAppCategoryUser(user_app_categories_parent1 user_app_categories_parent1)
        {
            try
            {
                var messages = userAppCategoriesRepository.AddUserAppCategoryUser(user_app_categories_parent1);
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
        [Route("api/EditUserAppCategories")]
        public IActionResult EditUserAppCategories(user_app_categories user_app_categories_Model)
        {
            try
            {
                var messages = userAppCategoriesRepository.EditUserAppCategories(user_app_categories_Model);
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
        [Route("api/GetALLUserAppCategories")]
        public IActionResult GetALLUserAppCategories()
        {
            try
            {
                var messages = userAppCategoriesRepository.GetALLUserAppCategories();
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
        [Route("api/DeleteUserCategory")]

        public IActionResult DeleteUserCategory(string UserCategoryId)
        {
            try
            {
                var messages = userAppCategoriesRepository.DeleteUserCategory(UserCategoryId);
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
        [Route("api/ReAssignUserApps")]
        public IActionResult ReAssignUserApps(user_app_categories_parent1 user_app_categories_parent1)
        {
            try
            {
                var messages = userAppCategoriesRepository.ReAssignUserApps(user_app_categories_parent1);
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
        [Route("api/ReAssignAppsDeleteUserId")]
        public IActionResult ReAssignAppsDeleteUserId(user_app_categories_parent1 user_app_categories_parent1)
        {
            try
            {
                var messages = userAppCategoriesRepository.ReAssignAppsDeleteUserId(user_app_categories_parent1);
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
 