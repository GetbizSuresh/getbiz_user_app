using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Business_Category_About_Demo;
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
    public class UserAppBusinessCategoryAboutDemoController : ControllerBase
    {
        private IUserAppBusinessCategoryAboutDemoRepository userAppBusinessCategoryAboutDemoRepository;
        public UserAppBusinessCategoryAboutDemoController(IUserAppBusinessCategoryAboutDemoRepository _userAppBusinessCategoryAboutDemoRepository)
        {
            userAppBusinessCategoryAboutDemoRepository = _userAppBusinessCategoryAboutDemoRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppAboutDemoCategories")]
        public IActionResult AddUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo)
        {
            try
            {
                var messages = userAppBusinessCategoryAboutDemoRepository.AddUserAppAboutDemoCategories(user_app_business_category_about_demo);
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
        [Route("api/EditUserAppAboutDemoCategories")]
        public IActionResult EditUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo)
        {
            try
            {
                var messages = userAppBusinessCategoryAboutDemoRepository.EditUserAppAboutDemoCategories(user_app_business_category_about_demo);
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
        [Route("api/GetALLUserAppAboutDemoCategories")]
        public IActionResult GetALLUserAppAboutDemoCategories()
        {
            try
            {
                var messages = userAppBusinessCategoryAboutDemoRepository.GetALLUserAppAboutDemoCategories();
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
        [Route("api/GetUserAppAboutDemoCategoriesById")]
        public IActionResult GetUserAppAboutDemoCategoriesById(string GetDemoCategoriesById)
        {
            try
            {
                var messages = userAppBusinessCategoryAboutDemoRepository.GetUserAppAboutDemoCategoriesById(GetDemoCategoriesById);
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
