using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Country_Business_Category_Location_Assignment;
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
    public class UserAppCountryBusinessCategoryLocationAssignmentController : ControllerBase
    {

        public readonly IUserAppCountryBusinessCategoryLocationAssignmentRepository userAppCountryBusinessCategoryLocationAssignmentRepository;

        public UserAppCountryBusinessCategoryLocationAssignmentController(IUserAppCountryBusinessCategoryLocationAssignmentRepository _userAppCountryBusinessCategoryLocationAssignmentRepository)
        {
            userAppCountryBusinessCategoryLocationAssignmentRepository = _userAppCountryBusinessCategoryLocationAssignmentRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppCountryBusinessCategoryLocationAssignment")]
        public IActionResult AddUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_app_country_business_category_location_assignment_Model)
        {
            try
            {
                var messages = userAppCountryBusinessCategoryLocationAssignmentRepository.AddUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment_Model);
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
        [Route("api/EditUserAppCountryBusinessCategoryLocationAssignment")]
        public IActionResult EditUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_app_country_business_category_location_assignment_Model)
        {
            try
            {
                var messages = userAppCountryBusinessCategoryLocationAssignmentRepository.EditUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment_Model);
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
        [Route("api/GetUserAppCountryBusinessCategoryLocationAssignment")]
        public IActionResult GetUserAppCountryBusinessCategoryLocationAssignment()
        {
            try
            {
                var messages = userAppCountryBusinessCategoryLocationAssignmentRepository.GetUserAppCountryBusinessCategoryLocationAssignment();
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

